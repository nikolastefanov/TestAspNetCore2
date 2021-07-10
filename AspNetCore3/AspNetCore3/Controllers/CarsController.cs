using AspNetCore3.Data;
using AspNetCore3.Data.Models;
using AspNetCore3.Models.Cars;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore3.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext db;

        public CarsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Add(CarInputModel car)
        {
            var carData = new Car
            {
                Make = car.Make,
            };

            this.db.Add(carData);

            this.db.SaveChanges();

            return this.RedirectToAction("Index","Home");
        }
    }
}
