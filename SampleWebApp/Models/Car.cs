using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApp.Models
{
    public class Car
    {
        [Column("ModelId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ModelId { get; set; }

        [Column("CarName")]
        [Required]
        public string CarName { get; set; }

        [Column("BrandName")]
        [Required]
        public string BrandName { get; set; }

        [Column("Year")]
        [Required]
        public int Year { get; set; }

        [Column("Varient")]
        [Required]
        public string Varient { get; set; }
    }
}
