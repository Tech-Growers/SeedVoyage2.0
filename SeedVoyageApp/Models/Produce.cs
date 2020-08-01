using System;
using System.Collections.Generic;

namespace SeedVoyageApp.Models
{
    public partial class Produce
    {
        public string GrowerEmail { get; set; }
        public int ProduceId { get; set; }
        public string ProduceName { get; set; }
        public string ProduceImage { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
    }
}
