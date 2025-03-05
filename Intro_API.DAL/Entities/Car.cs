using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro_API.DAL.Entities
{
    public class Car
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(100)]
        public required string Model { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Brand { get; set; }
        public int Year { get; set; }
    }
}
