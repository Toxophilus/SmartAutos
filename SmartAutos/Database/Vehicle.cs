namespace SmartAutos.Database
{
    public partial class Vehicle
    {
        public int Id { get; set; }
        public int? Model { get; set; }
        public int EngineSize { get; set; }
        public int? Colour { get; set; }
        public string Registration { get; set; }
        public int Mileage { get; set; }

        public virtual Colour ColourNavigation { get; set; }
        public virtual Model ModelNavigation { get; set; }
    }
}
