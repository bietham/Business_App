using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Task3.Store.Models;

namespace Task3.ViewModels
{
    public class InventoryCreateViewModel
    {
        public int SchoolId { get; set; }
        public SchoolViewModel School { get; set; }

        [Required(ErrorMessage = "Inventory name cannot be empty.")]
        [Display(Name = "Inventory Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select measurement unit.")]
        [Display(Name = "Measurement unit")]
        public string MeasurementUnit { get; set; }

        [Required(ErrorMessage = "Please inventory amount.")]
        [Display(Name = "Inventory Amount")]
        public float Amount { get; set; }

        [Required(ErrorMessage = "Please select the type of inventory.")]
        [Display(Name = "Inventory Type")]
        public int? SelectedTypeId { get; set; }
        public List<InventoryTypeViewModel> InventoryTypes { get; set; }

        public bool Analogous { get; set; }


    }
}
