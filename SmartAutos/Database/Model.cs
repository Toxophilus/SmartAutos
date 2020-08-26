using System.Collections.Generic;

namespace SmartAutos.Database
{
    public partial class Model
    {
        public Model()
        {
            Vehicle = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
