using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartAutos.Models;
using SmartAutos.Repository;

namespace SmartAutos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Vehicle vehicle = new Vehicle();
            return View(vehicle.GetAll());
        }

        public IActionResult DeleteVehicle(int id)
        {
            Vehicle vehicle = new Vehicle();
            vehicle.Delete(id);
            return Redirect("/");
        }

        public IActionResult AddVehicle()
        {
            if (!Request.HasFormContentType)
            {
                VehicleAdding vehicleDb = new VehicleAdding();
                VehicleViewModel vehicle = vehicleDb.Create();

                return View("AddVehicle", vehicle);
            }
            else
            {
                VehicleViewModel vehicle = new VehicleViewModel();
                Vehicle vehicleDb = new Vehicle();

                vehicle.Id = int.Parse(Request.Form["Id"]);
                vehicle.ManufacturerId = int.Parse(Request.Form["Manufacturer"]);
                vehicle.ModelId = int.Parse(Request.Form["Model"]);
                vehicle.ColourId = int.Parse(Request.Form["Colour"]);
                vehicle.Milage = int.Parse(Request.Form["Milage"]);
                vehicle.Registration = Request.Form["Registration"];
                vehicle.EngineSize = int.Parse(Request.Form["EngineSize"]);
                vehicleDb.Add(vehicle);
            }

            return Redirect("/");
        }

        public IActionResult EditVehicle(int id)
        {
            Vehicle vehicleDb = new Vehicle();
            VehicleViewModel vehicle = vehicleDb.Get(id);
            if (vehicle != null)
            {
                if (!Request.HasFormContentType)
                {
                    return View("EditVehicle", vehicle);
                }
                else
                {
                    vehicle.Id = int.Parse(Request.Form["Id"]);
                    vehicle.ManufacturerId = int.Parse(Request.Form["Manufacturer"]);
                    vehicle.ModelId = int.Parse(Request.Form["Model"]);
                    vehicle.ColourId = int.Parse(Request.Form["Colour"]);
                    vehicle.Milage = int.Parse(Request.Form["Milage"]);
                    vehicle.Registration = Request.Form["Registration"];
                    vehicle.EngineSize = int.Parse(Request.Form["EngineSize"]);
                    vehicleDb.Update(vehicle);
                }
            }

            return Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public ActionResult GetModels(int manufacturerId)
        {
            Repository.Models models = new Repository.Models();
            List<ModelsViewModel> availableModels = models.GetFor(manufacturerId);
            return Json(availableModels);
        }
    }
}
