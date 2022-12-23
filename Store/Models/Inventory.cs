using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Task3.Store.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }
        public int? SchoolId { get; set; }
        public School School { get; set; }
        public string MeasurementUnit { get; set; } //enum
        [Required]
        public string Name { get; set; }
        public int? TypeId { get; set; }
        public InventoryType InventoryType { get; set; }
        public float Amount { get; set; }
        public float Rented { get; set; }
        public float Missing { get; set; }
        public bool Analogous { get; set; }
        public IEnumerable<AllocatedInventory> AllocatedInventories { get; set; }
        public IEnumerable<RequestedInventory> RequestedInventories { get; set; }
    }
}
