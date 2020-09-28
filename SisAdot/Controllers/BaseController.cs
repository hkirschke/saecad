using SisAdot.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SisAdot.Controllers
{
  public class BaseController : Controller
  {
    protected readonly SisAdotContext _sisAdotContext = new SisAdotContext();

    // GET: Base
    [AllowAnonymous]
    public virtual ActionResult Index()
    {
      return View();
    }
  }
}