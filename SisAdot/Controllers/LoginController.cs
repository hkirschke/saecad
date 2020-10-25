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
        [HttpPost]
        public ActionResult Autenticar(Usuario usuario)
        {
            var user = (from userlist in _sisAdotContext.Usuarios
                        where userlist.Login == usuario.Login && userlist.Senha == usuario.Senha
                        select new
                        {
                            userlist.UsuarioID,
                            userlist.Login,
                            userlist.PerfilUsuario,
                        }).ToList();
            var usuarioEncontrado = user.FirstOrDefault();
            if (usuarioEncontrado != null)
            {
                TempData["Perfil"] = usuarioEncontrado.PerfilUsuario;
                //ViewBag.Perfil = user.FirstOrDefault().PerfilUsuario;
                //Session["UserName"] = user.FirstOrDefault().Nome;
                //Session["UserID"] = user.FirstOrDefault().UsuarioID;
                if (usuarioEncontrado.PerfilUsuario == PerfilUsuario.Administrador) 
                    return Redirect("/Usuario/index");
                else
                    return Redirect("/Home/index");
            }
            else
            {
                ModelState.AddModelError("", "Login/senha Inválido");
            }
            return View("Index");
        } 
    }
}
