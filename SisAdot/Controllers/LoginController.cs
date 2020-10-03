using SisAdot.Enums;
using SisAdot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SisAdot.Controllers
{
  public class LoginController : BaseController
  {  
    // POST: Login/Autenticar
    [AllowAnonymous]
    public ActionResult Autenticar(Usuario usuario)
    {
      if (ModelState.IsValid)
      { 
        var user = (from userlist in _sisAdotContext.Usuarios
                    where userlist.Login == usuario.Login && userlist.Senha == usuario.Senha
                    select new
                    {
                      userlist.UsuarioID,
                      userlist.Login,
                      userlist.PerfilUsuario,
                    }).ToList();
        if (user.FirstOrDefault() != null)
        {
          //Session["UserName"] = user.FirstOrDefault().Nome;
          //Session["UserID"] = user.FirstOrDefault().UsuarioID;
          if (user.FirstOrDefault().PerfilUsuario == PerfilUsuario.Administrador)
              return Redirect("/Usuario/index");
          else
            return Redirect("/Home/index");
        }
        else
        {
          ModelState.AddModelError("", "Login/senha Inválido");
        }
      }
      return View();
    } 
  }
}
