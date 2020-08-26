using SmartAutos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAutos.DTOs
{
    public class VehicleDto
    {
        public static VehicleViewModel VehicleViewModelDTO(Database.Vehicle vehicle, Repository.Colours colours, Repository.Models models, Repository.Manufacturers manufacturers)
        {
            return new VehicleViewModel()
            {
                Id = vehicle.Id,
                EngineSize = vehicle.EngineSize,
                Registration = vehicle.Registration,
                Milage = vehicle.Mileage,
                ColourId = vehicle.Colour,
                Colour = colours.Get(vehicle.Colour ?? 0).Name,
                ModelId = vehicle.Model,
                Model = models.Get(vehicle.Model ?? 0).Name,
                ManufacturerId = models.Get(vehicle.Model).ManufacturerId,
                Manufacturer = manufacturers.Get(models.Get(vehicle.Model).ManufacturerId).Name,
                AvailableColours = colours.GetAll(),
                AvailableModels = models.GetAll(),
                AvailableManufactrurers = manufacturers.GetAll()
            };
        }
        public static VehicleListViewModel VehicleListViewModelDTO(Database.Vehicle vehicle, Repository.Colours colours, Repository.Models models, Repository.Manufacturers manufacturers)
        {
            return new VehicleListViewModel()
            {
                Id = vehicle.Id,
                EngineSize = vehicle.EngineSize,
                Registration = vehicle.Registration,
                Milage = vehicle.Mileage,
                ColourId = vehicle.Colour,
                Colour = colours.Get(vehicle.Colour ?? 0).Name,
                ModelId = vehicle.Model,
                Model = models.Get(vehicle.Model ?? 0).Name,
                Manufacturer = manufacturers.Get(models.Get(vehicle.Model).ManufacturerId).Name,
            };
        }
        public static VehicleViewModel VehicleAddViewModelDTO(Repository.Colours colours, Repository.Models models, Repository.Manufacturers manufacturers)
        {
            return new VehicleViewModel()
            {
                AvailableColours = colours.GetAll(),
                AvailableModels = models.GetAll(),
                AvailableManufactrurers = manufacturers.GetAll()
            };
        }
    }
}
