using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Task3.Store.Models;

namespace Task3.ViewModels
{
    public class PlannedInventoryEditViewModel
    {

        public int? RentRequestId { get; set; }
        public RentRequest RentRequest { get; set; }
        public IEnumerable<AllocatedInventory> AllocatedInventories { get; set; }
        public int? InventoryId { get; set; }
        
        [Required(ErrorMessage = "Inventory must be selected.")]
        [Display(Name = "Inventory")]
        public Inventory Inventory { get; set; }
        public string MeasurementUnit { get; set; } //enum

        [Required(ErrorMessage = "Select amount of inventory to plan.")]
        [Display(Name = "Inventory Amount")]
        public float Amount { get; set; }
    }
}
