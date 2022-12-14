using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Task3.Store.Models
{
    public enum Approval
    {
        NotApproved, PartiallyApproved, Approved
    }
    public class RentRequest
    {
        [Key]
        public int Id { get; set; }
        public int? EventId { get; set; }
        public Event Event { get; set; }
        public int? SchoolId { get; set; }
        public School School { get; set; }
        public Approval Approval { get; set; }
        public IEnumerable<PlannedInventory> PlannedInventories { get; set; }
        public IEnumerable<AllocatedInventory> AllocatedInventories { get; set; }
        public IEnumerable<RequestedInventory> RequestedInventories { get; set; } // type to quantity in the original
        public IEnumerable<ReturnRequest> ReturnRequests { get; set; }
        public IEnumerable<UnloadRequest> UnloadRequests { get; set; }
    }
}
