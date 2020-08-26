using SmartAutos.Database;
using SmartAutos.DTOs;
using SmartAutos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SmartAutos.Repository
{
    public class Vehicle
    {
        public List<VehicleListViewModel> GetAll()
        {
            List<VehicleListViewModel> vehicles = new List<VehicleListViewModel>();

            using (var db = new SmartAutosContext())
            {
                List<Database.Vehicle> vehicleDb = db.Vehicle.Select(x => x).ToList();
                foreach (var item in vehicleDb)
                {
                    vehicles.Add(VehicleDto.VehicleListViewModelDTO(item, new Colours(), new Models(), new Manufacturers()));
                }
            }

            return vehicles;
        }

        public void Delete(int id)
        {
            using (var db = new SmartAutosContext())
            {
                Database.Vehicle vehicle = db.Vehicle.FirstOrDefault(vehicle => vehicle.Id == id);
                if (vehicle != null)
                {
                    db.Vehicle.Remove(vehicle);
                    db.SaveChanges();
                }
            }
        }

        public VehicleViewModel Get(int id)
        {
            using (var db = new SmartAutosContext())
            {
                Database.Vehicle vehicle = db.Vehicle.FirstOrDefault(vehicle => vehicle.Id == id);
                if (vehicle != null)
                {
                    return VehicleDto.VehicleViewModelDTO(vehicle, new Colours(), new Models(), new Manufacturers());
                }
                else
                {
                    throw new Exception("Vehicle not found");
                }
            }
        }

        public void Update(VehicleViewModel vehicleData)
        {
            using (var db = new SmartAutosContext())
            {
                Database.Vehicle vehicle = db.Vehicle.FirstOrDefault(vehicle => vehicle.Id == vehicleData.Id);
                if (vehicle != null)
                {
                    vehicle.Registration = vehicleData.Registration;
                    vehicle.Mileage = vehicleData.Milage;
                    vehicle.EngineSize = vehicleData.EngineSize;
                    vehicle.Colour = vehicleData.ColourId;
                    vehicle.Model = vehicleData.ModelId;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Vehicle not found");
                }
            }
        }

        public void Add(VehicleViewModel vehicleData)
        {
            using (var db = new SmartAutosContext())
            {
                Database.Vehicle vehicle = new Database.Vehicle();
                vehicle.Registration = vehicleData.Registration;
                vehicle.Mileage = vehicleData.Milage;
                vehicle.EngineSize = vehicleData.EngineSize;
                vehicle.Colour = vehicleData.ColourId;
                vehicle.Model = vehicleData.ModelId;

                db.Vehicle.Add(vehicle);
                db.SaveChanges();
            }
        }
    }
}
