using System;
using System.Web.Mvc;
using Consultorio.Domain.Models;
using Consultorio.Service.Infrastructure;
using Consultorio.Service;
using System.Web.Security;

namespace ConsultorioDDD.Controllers
{
    public class HomeController : Controller
    {
        IUsuarioService _service = new UsuarioService();

        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            Usuario usuario = new Usuario();
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(Usuario usuario, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_service.ValidatePassword(usuario.Codigo, usuario.Password))
                    {
                        FormsAuthentication.SetAuthCookie(usuario.Codigo, false);

                        if (this.Url.IsLocalUrl(returnUrl))
                            return Redirect(returnUrl);
                        else
                            return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Login", "Credencial inválida");
                    }
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Login", string.Format("Erro ao efetuar login: {0}", ex.Message));
            }
            return View(usuario);
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Home");
        }
    }
}