using System.Collections.Generic;

namespace SmartAutos.Database
{
    public partial class Colour
    {
        public Colour()
        {
            Vehicle = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
