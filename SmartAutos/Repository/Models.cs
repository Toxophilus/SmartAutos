using SmartAutos.Database;
using SmartAutos.DTOs;
using SmartAutos.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartAutos.Repository
{
    public class Models
    {
        public List<ModelsViewModel> GetAll()
        {
            List<ModelsViewModel> models = new List<ModelsViewModel>();
            using (var db = new SmartAutosContext())
            {
                foreach (var item in db.Model.Select(x => x).ToList())
                {
                    models.Add(ModelDto.ModelViewModelDTO(item));
                }
            }

            return models;
        }

        public ModelsViewModel Get(int? id)
        {
            using (var db = new SmartAutosContext())
            {
                return ModelDto.ModelViewModelDTO(db.Model.FirstOrDefault(x => x.Id == id));
            }
        }

        public List<ModelsViewModel> GetFor(int? manufacturerId)
        {
            if (manufacturerId == null)
            {
                return GetAll();
            }
            else
            {
                List<ModelsViewModel> models = new List<ModelsViewModel>();
                using (var db = new SmartAutosContext())
                {
                    foreach (var item in db.Model.Where(x => x.ManufacturerId == manufacturerId).ToList())
                    {
                        models.Add(ModelDto.ModelViewModelDTO(item));
                    }
                }

                return models;
            }
        }
    }
}
