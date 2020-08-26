namespace SmartAutos.Models
{
    public class VehicleListViewModel
    {
        public int Id { get; set; }
        public int? ColourId { get; set; }
        public string Colour { get; set; }
        public string Manufacturer { get; set; }
        public int Milage { get; set; }
        public int EngineSize { get; set; }
        public int? ModelId { get; set; }
        public string Model { get; set; }
        public string Registration { get; set; }
    }
}
