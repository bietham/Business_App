using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using Task3.Store.Models;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace Task3.ViewModels
{
    public class EventCreateViewModel
    {
        [Required(ErrorMessage = "Event name can't be empty")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        public EventStatus EventStatus { get; set; }
        [Required(ErrorMessage = "Start time can't be empty")]
        [Display(Name = "Start time")]
        public DateTime? StartTime { get; set; }
        
        [Required(ErrorMessage = "End time can't be empty")]
        [Display(Name = "End time")]
        public DateTime? EndTime { get; set; }
        [Required(ErrorMessage = "Location can't be empty")]
        [Display(Name = "Location")]
        public string Location { get; set; }

        public string MastermindId { get; set; }
        public string DeliverymanId { get; set; }
        public IdentityUser Deliveryman { get; set; }
        public IdentityUser Mastermind { get; set; }
        public IEnumerable<InventoryType> InventoryTypes { get; set; }
        public IEnumerable<PlannedInventoryViewModel> PlannedInventories { get; set; }
        public List<(int, float)> SelectedTypeIds { get; set; }
        // курьер
    }
}
