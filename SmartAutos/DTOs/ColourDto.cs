using SmartAutos.Database;
using SmartAutos.Models;

namespace SmartAutos.DTOs
{
    public class ColourDto
    {
        public static ColoursViewModel ColourViewModelDTO(Colour colour)
        {
            return new ColoursViewModel()
            {
                Id = colour.Id,
                Name = colour.Name
            };
        }
    }
}
