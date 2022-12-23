using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Task3.ViewModels
{
    public class AllocatedInventoryViewModel
    {
        [Key]
        public int Id { get; set; }
        public int? EventId { get; set; }
        public EventViewModel Event { get; set; }
        public int? PlannedInventoryId { get; set; }
        [Required]
        public PlannedInventoryViewModel PlannedInventory { get; set; }
        public int? RentRequestId { get; set; }
        [Required]
        public RentRequestViewModel RentRequest { get; set; }
        public int? InventoryId { get; set; }
        public InventoryViewModel Inventory { get; set; }
        public int? ReturnRequestId { get; set; }
        public ReturnRequestViewModel ReturnRequest { get; set; }
        public string MeasurementUnit { get; set; } //enum
        public float Amount { get; set; }
        public float AmountUsed { get; set; }
        public float Missing { get; set; }
        public bool Analogous { get; set; }
    }
}
