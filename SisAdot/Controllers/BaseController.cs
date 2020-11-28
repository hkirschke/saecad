using SisAdot.Data;
using SisAdot.DataUtil;
using SisAdot.Extensions;
using System.Globalization;
using System.Web.Mvc;

namespace SisAdot.Controllers
{
    public class BaseController : Controller
    {
        protected readonly SisAdotContext _sisAdotContext = new SisAdotContext();
        protected readonly SisAdotContextAnimalUtil _sisAdotContextAnimalUtil = new SisAdotContextAnimalUtil();
        protected readonly SisAdotContextFichaUtil _sisAdotContextFichaUtil = new SisAdotContextFichaUtil();
        protected readonly CultureInfo CultureInfo = CultureInfo.CreateSpecificCulture("fr-FR");

        /// <summary>
        /// {} realizado com sucesso!
        /// </summary>
        protected const string MensgemSucessoPadrao = "{0} com sucesso!";
        /// <summary>
        /// Erro ao efetuar \n{0}!
        /// </summary>
        protected const string MensgemErroPadrao = "Erro ao efetuar \n{0}!";
        /// <summary>
        /// Atenção! \n{0}
        /// </summary>
        protected const string MensgemAvisoPadrao = "Atenção! \n{0}";


        // GET: Base
        [AllowAnonymous]
        public virtual ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// {0} realizado com sucesso!
        /// </summary>
        public void AddNotificacaoSucesso(string acao)
        {
            this.AddNotification(string.Format(MensgemSucessoPadrao, acao), Extensions.NotificationType.SUCCESS);
        }
        /// <summary>
        /// Atenção! \n{0}
        /// </summary>
        public void AddNotificacaoAviso(string acao)
        {
            this.AddNotification(string.Format(MensgemAvisoPadrao, acao), Extensions.NotificationType.WARNING);
        }
        /// <summary>
        /// Erro ao efetuar \n{0}!
        /// </summary>
        public void AddNotificacaoErro(string acao)
        {
            this.AddNotification(string.Format(MensgemErroPadrao, acao), Extensions.NotificationType.ERROR);
        }

        public void AddNotificacaoInformacao(string acao)
        {
            this.AddNotification(string.Format("{0}", acao), Extensions.NotificationType.INFO);
        }
    }
}