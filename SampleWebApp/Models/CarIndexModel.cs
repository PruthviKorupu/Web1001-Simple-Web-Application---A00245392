using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApp.Models
{
    public class CarIndexModel : Car
    {
        public string SearchText { get; set; }

        public List<Car> Cars { get; set; }
    }
}
