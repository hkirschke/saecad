using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SisAdot.Enums
{
    public enum Situacao
    {
        Adotado,
        [Display(Name = "Disponível", Description = "Disponível")]
        Disponivel,
        [Display(Name = "Dono Próprio", Description = "Dono Próprio")]
        DonoProprio
    }
}