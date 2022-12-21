using System.Collections.Generic;
using Task3.Store.Models;

namespace Task3.ViewModels
{
    public class RentRequestViewModel
    {
        public int Id { get; set; }
        public int? EventId { get; set; }
        public Event Event { get; set; }
        public int? SchoolId { get; set; }
        public School School { get; set; }
        public Approval Approval { get; set; }
        public List<PlannedInventory> PlannedInventories { get; set; }
        public List<AllocatedInventory> AllocatedInventories { get; set; }
        public List<RequestedInventory> RequestedInventories { get; set; } // type to quantity in the original
        public List<ReturnRequest> ReturnRequests { get; set; }
        public List<UnloadRequest> UnloadRequests { get; set; }

    }
}
