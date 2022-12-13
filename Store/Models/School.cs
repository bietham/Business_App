using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Task3.Store.Models
{
    public class School
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Location { get; set; }
        public IEnumerable<Inventory> Inventory { get; set; }
    }
}
