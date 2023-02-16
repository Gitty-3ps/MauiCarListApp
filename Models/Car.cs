using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarListApp.Models
{
    public class Car : BaseEntity
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Vin { get; set; }
    }

}
