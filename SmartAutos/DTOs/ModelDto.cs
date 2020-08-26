using SmartAutos.Database;
using SmartAutos.Models;

namespace SmartAutos.DTOs
{
    public class ModelDto
    {
        public static ModelsViewModel ModelViewModelDTO(Model model)
        {
            return new ModelsViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                ManufacturerId = (model.ManufacturerId ?? 0)
            };
        }
    }
}
