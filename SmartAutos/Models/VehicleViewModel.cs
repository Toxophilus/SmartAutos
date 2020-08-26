using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartAutos.Models
{
    public class VehicleViewModel
    {
        public int Id { get; set; }
        
        public int? ColourId { get; set; }

        [Required]
        [DisplayName("Vehicle Colour")]
        public string Colour { get; set; }
        public int? ManufacturerId { get; set; }
        
        [Required]
        [DisplayName("Vehicle Manufacturer")]
        public string Manufacturer { get; set; }

        [Required]
        [Range(1,999999, ErrorMessage = "The vehicles milage must be between 1 and 999999 miles")]
        [DisplayName("Milage")]
        public int Milage { get; set; }

        [Required]
        [Range(500, 8000, ErrorMessage = "The vehicles engine size must be between 500 and 8000 cc")]
        [DisplayName("Engine Size")]
        public int EngineSize { get; set; }
        public int? ModelId { get; set; }

        [Required]
        [DisplayName("Vehicle Model")]
        public string Model { get; set; }

        [Required]
        [MaxLength(8, ErrorMessage = "The vehicle registration can be no longer than 8 characters")]
        [MinLength(3, ErrorMessage = "The vehicle registration must be at least 3 characters")]
        [DisplayName("Vehicle Registration")]
        public string Registration { get; set; }
        public List<ColoursViewModel> AvailableColours { get; set; }
        public List<ModelsViewModel> AvailableModels { get; set; }
        public List<ManufacturersViewModel> AvailableManufactrurers { get; set; }
    }
}
