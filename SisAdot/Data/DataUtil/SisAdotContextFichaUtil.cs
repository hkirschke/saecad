using SisAdot.Data;
using SisAdot.Models;
using SisAdot.Models.Animal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SisAdot.DataUtil
{
    public class SisAdotContextFichaUtil : SisAdotContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        /// <summary>
        /// Verifica se há um agendamento com menos de 20 minutos de diferença
        /// </summary>
        /// <returns></returns>
        public List<FichaCastracao> ValidaAgenda(DateTime? horaMarcacao, Guid equipeID)
        {
            List<FichaCastracao> ListAgendainvalida = new List<FichaCastracao>();
            if (horaMarcacao != null)
            {
                var newhoraMarcacao = Convert.ToDateTime(horaMarcacao);
                ListAgendainvalida = (from fichaList in FichaCastracaos.ToList()
                                      where (fichaList.DataEntrada?.Subtract(newhoraMarcacao))?.TotalMinutes < 20
                                      && fichaList.EquipeVeterinarioID == equipeID
                                      select new FichaCastracao
                                      {
                                          CastracaoID = fichaList.CastracaoID,
                                          DataEntrada = fichaList.DataEntrada
                                      }).ToList();
            }
            return ListAgendainvalida;
        }
    }
}
