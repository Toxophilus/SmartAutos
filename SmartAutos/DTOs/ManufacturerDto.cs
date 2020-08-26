using SmartAutos.Database;
using SmartAutos.Models;

namespace SmartAutos.DTOs
{
    public class ManufacturerDto
    {
        public static ManufacturersViewModel ManufacturersViewModelDTO(Manufacturer manufacturer)
        {
            return new ManufacturersViewModel()
            {
                Id = manufacturer.Id,
                Name = manufacturer.Name,
            };
        }
    }
}
