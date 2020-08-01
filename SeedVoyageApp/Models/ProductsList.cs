using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeedVoyageApp.Models
{
    public partial class ProductsList
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductLocation { get; set; }
        public DateTime UploadedDate { get; set; }
        public int ProductOwnerId { get; set; }
    }
}
