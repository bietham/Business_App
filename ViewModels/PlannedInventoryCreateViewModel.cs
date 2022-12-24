using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Task3.Store.Models;

namespace Task3.ViewModels
{
    public class PlannedInventoryCreateViewModel
    {
        public int? EventId { get; set; }
        public Event Event { get; set; }

        [Required(ErrorMessage = "Inventory type must be selected.")]
        [Display(Name = "Inventory Type")]
        public int? SelectedInventoryTypeId { get; set; }
        public List<InventoryTypeViewModel> InventoryTypes { get; set; }
        public string MeasurementUnit { get; set; } //enum

        [Required(ErrorMessage = "Select amount of inventory to plan.")]
        [Display(Name = "Inventory Amount")]
        public float Amount { get; set; }


    }
}
