using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Task3.Store.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public IEnumerable<PlannedInventory> PlannedInventories { get; set; }
        public IEnumerable<AllocatedInventory> AllocatedInventories { get; set; }
        public IEnumerable<RentRequest> RentRequests { get; set; }
        public IdentityUser Mastermind { get; set; }
        public IdentityUser Deliveryman { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public EventStatus EventStatus { get; set; }
        public string Location { get; set; }
    }
}
