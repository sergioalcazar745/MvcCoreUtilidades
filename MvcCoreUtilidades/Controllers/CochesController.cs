using Microsoft.AspNetCore.Mvc;
using MvcCoreUtilidades.Models;

namespace MvcCoreUtilidades.Controllers
{
    public class CochesController : Controller
    {
        private List<Coche> Cars;
        public CochesController()
        {
            this.Cars = new List<Coche>
            {
                new Coche{IdCoche = 1, Marca = "Pontiac", Modelo = "Firebird", Imagen = "https://img.remediosdigitales.com/672f3a/1976-firebird-trans-am/1366_2000.jpg"},
                new Coche{IdCoche = 2, Marca = "Volkswagen", Modelo = "Escarabajo", Imagen = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ0_IqCvoZHDNUuh2U8ew3P2mXx1meW2fKd45-kxMqp-SlSW0X4TXiTRJIm3HvJIPRuBRI&usqp=CAU"},
                new Coche{IdCoche = 3, Marca = "Ferrari", Modelo = "Testarrosa", Imagen = "https://img.remediosdigitales.com/2b4292/ferrari/1366_2000.jpg"},
                new Coche{IdCoche = 4, Marca = "Ford", Modelo = "Mustang GT", Imagen = "https://www.km77.com/revista/wp-content/files/2016/04/Ford-Mustang-_01.jpg"},
            };
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int idcoche)
        {
            Coche car = this.Cars.FirstOrDefault(x => x.IdCoche == idcoche);
            return View(car);
        }

        public IActionResult _CochesPartial()
        {
            return PartialView("_CochesPartial", this.Cars);
        }

        public IActionResult _DetailsPartial(int idcoche)
        {
            Coche car = this.Cars.FirstOrDefault(x => x.IdCoche == idcoche);
            return PartialView("_DetailsPartial", car);
        }
    }
}
