using Microsoft.AspNetCore.Mvc;
using MvcCoreUtilidades.Helpers;

namespace MvcCoreUtilidades.Controllers
{
    public class CifradosController : Controller
    {
        public IActionResult CifradoBasico()
        {
            string resultado = HelperCryptography.EncriptarTextoBasico("a12345");
            ViewData["TEXTOCIFRADO"] = resultado;
            return View();
        }
    }
}
