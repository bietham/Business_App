using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using Task3.Store.Models;
using Microsoft.AspNetCore.Identity;

namespace Task3.ViewModels
{
    public class EventEditViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите название мероприятия")]
        [Display(Name = "Название мероприятия")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Укажите дату начала мероприятия")]
        [Display(Name = "Дата начала")]
        public DateTime StartTime { get; set; }
        [Required(ErrorMessage = "Укажите дату окончания мероприятия")]
        [Display(Name = "Дата окончания")]
        public DateTime EndTime { get; set; }
        [Required(ErrorMessage = "Укажите место проведения мероприятия")]
        [Display(Name = "Место проведения")]
        public string Location { get; set; }

        public string MastermindId { get; set; }
        public string DeliverymanId { get; set; }

        public IdentityUser Deliveryman { get; set; }
        public IdentityUser Mastermind { get; set; }


        public IEnumerable<PlannedInventoryViewModel> PlannedInventories { get; set; }
        // курьер
    }
}
