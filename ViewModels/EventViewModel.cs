using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using Task3.Store.Models;
using Microsoft.AspNetCore.Identity;

namespace Task3.ViewModels
{
    public class EventViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public EventStatus EventStatus { get; set; }
        public DateTime StartTime { get; set; }

        public string MastermindId { get; set; }
        public string DeliverymanId { get; set; }
        public IdentityUser Deliveryman { get; set; }
        public IdentityUser Mastermind { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public IEnumerable<PlannedInventoryViewModel> PlannedInventories { get; set; }
        public IEnumerable<RentRequest> RentRequests { get; set; }
    }
}
