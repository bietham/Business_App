using System.ComponentModel.DataAnnotations;
using Task3.Store.Models;

namespace Task3.ViewModels
{
    public class PlannedInventoryCreateViewModel
    {
        public int? EventId { get; set; }
        public Event Event { get; set; }
        public int? InventoryId { get; set; }

        [Required(ErrorMessage = "Inventory must be selected.")]
        [Display(Name = "Inventory")]
        public InventoryViewModel Inventory { get; set; }
        public string MeasurementUnit { get; set; } //enum

        [Required(ErrorMessage = "Select amount of inventory to plan.")]
        [Display(Name = "Inventory Amount")]
        public float Amount { get; set; }


    }
}
