using SisAdot.Enums;
using SisAdot.Extensions;
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
                this.AddNotification($"Bem vindo Herói!", NotificationType.INFO);
                Session["Perfil"] = usuarioEncontrado.PerfilUsuario;
                Session["UsuarioID"] = usuarioEncontrado.UsuarioID;
                //if (usuarioEncontrado.PerfilUsuario == PerfilUsuario.Administrador)
                //    return Redirect("/Usuario/index");
                //else
                    return Redirect("/Home/index");
            }
            else
            {
                this.AddNotification("Login/senha Inválido", NotificationType.ERROR); 
            }
            return View("Index");
        }

        public override ActionResult Index()
        {
            Session["Perfil"] = PerfilUsuario.Adotante;
            Session["UsuarioID"] = "";
            return base.Index();
        }

    }
}
