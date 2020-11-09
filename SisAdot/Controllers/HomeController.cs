using SisAdot.Extensions;
using SisAdot.Models.Animal;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SisAdot.Controllers
{
    public class HomeController : BaseController
    {
        public override ActionResult Index()
        { 
            List<AnimalViewModel> animaisDoacao = _sisAdotContextAnimalUtil.AnimaisDoacoes();
            return View(animaisDoacao);
        }
    }
}