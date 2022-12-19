using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Task3.Store.Models;

namespace Task3.ViewModels
{
    public class InventoryEditViewModel
    {
        public int Id { get; set; }
        public int? SchoolId { get; set; }
        public School School { get; set; }

        [Required(ErrorMessage = "Inventory name cannot be empty.")]
        [Display(Name = "Inventory Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select measurement unit.")]
        [Display(Name = "Measurement unit")]
        public string MeasurementUnit { get; set; }

        [Required(ErrorMessage = "Please type inventory amount.")]
        [Display(Name = "Inventory Amount")]
        public bool Analogous { get; set; }




    }
}
