using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc; 

namespace SisAdot.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }
  }
}