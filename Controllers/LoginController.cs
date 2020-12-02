using Sistema_TuTienda_Lizarraga_Belizario_Loja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_TuTienda_Lizarraga_Belizario_Loja.Filters;

namespace Sistema_TuTienda_Lizarraga_Belizario_Loja.Controllers
{
    public class LoginController : Controller
    {
        private USUARIO usuario = new USUARIO();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Validar(string Usuario, string Password)
        {
            var rm = usuario.ValidarLogin(Usuario, Password);

            if (rm.response)
            {
                rm.href = Url.Content("/Default/Index");
            }

            return Json(rm);
        }

        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/Login");
        }
    }
}