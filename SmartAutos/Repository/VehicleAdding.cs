using SmartAutos.Database;
using SmartAutos.DTOs;
using SmartAutos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SmartAutos.Repository
{
    public class VehicleAdding
    {
        public VehicleViewModel Create()
        {
            using (var db = new SmartAutosContext())
            {
                return VehicleDto.VehicleAddViewModelDTO(new Colours(), new Models(), new Manufacturers());
            }
        }
    }
}
