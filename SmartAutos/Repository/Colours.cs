using SmartAutos.Database;
using SmartAutos.Models;
using System.Collections.Generic;
using System.Linq;
using SmartAutos.DTOs;

namespace SmartAutos.Repository
{
    public class Colours
    {
        public List<ColoursViewModel> GetAll()
        {
            List<ColoursViewModel> colours = new List<ColoursViewModel>();
            using (var db = new SmartAutosContext())
            {
                foreach (var item in db.Colour.Select(x => x).ToList())
                {
                    colours.Add(ColourDto.ColourViewModelDTO(item));
                }
            }

            return colours;
        }

        public ColoursViewModel Get(int? id)
        {
            using (var db = new SmartAutosContext())
            {
                return ColourDto.ColourViewModelDTO(db.Colour.FirstOrDefault(x => x.Id == id));
            }
        }
    }
}
