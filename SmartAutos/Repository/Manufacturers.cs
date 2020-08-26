using SmartAutos.Database;
using SmartAutos.DTOs;
using SmartAutos.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartAutos.Repository
{
    public class Manufacturers
    {
        public List<ManufacturersViewModel> GetAll()
        {
            List<ManufacturersViewModel> manufacturers = new List<ManufacturersViewModel>();
            using (var db = new SmartAutosContext())
            {
                foreach (var item in db.Manufacturer.Select(x => x).ToList())
                {
                    manufacturers.Add(ManufacturerDto.ManufacturersViewModelDTO(item));
                }
            }

            return manufacturers;
        }

        public ManufacturersViewModel Get(int? id)
        {
            using (var db = new SmartAutosContext())
            {
                return ManufacturerDto.ManufacturersViewModelDTO(db.Manufacturer.FirstOrDefault(x => x.Id == id));
            }
        }
    }
}
