using System.Collections.Generic;

namespace SmartAutos.Database
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Model = new HashSet<Model>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Model> Model { get; set; }
    }
}
