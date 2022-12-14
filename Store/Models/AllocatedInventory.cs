using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Task3.Store.Models
{
    public class AllocatedInventory
    {
        [Key]
        public int Id { get; set; }
        public int? EventId { get; set; }
        public Event Event { get; set; }
        public int? PlannedInventoryId { get; set; }
        [Required]
        public PlannedInventory PlannedInventory { get; set; }
        public int? RentRequestId { get; set; }
        [Required]
        public RentRequest RentRequest { get; set; }
        public int? InventoryId { get; set; }
        public Inventory Inventory { get; set; }
        public int? ReturnRequestId { get; set; }
        public ReturnRequest ReturnRequest { get; set; }

        public string MeasurementUnit { get; set; } //enum
        public float Amount { get; set; }
        public float AmountUsed { get; set; }
        public float Missing { get; set; }
        public bool Analogous { get; set; }
    }
}
