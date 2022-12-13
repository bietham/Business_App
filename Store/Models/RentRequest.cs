using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Task3.Store.Models
{
    public class RentRequest
    {
        [Key]
        public int Id { get; set; }
        public int? EventId { get; set; }
        public Event Event { get; set; }
        public int? SchoolId { get; set; }
        public School School { get; set; }
        public IEnumerable<PlannedInventory> PlannedInventories { get; set; }
        public Dictionary<int, string> InventoryTypeToQuantity { get; set; }
    }
}
