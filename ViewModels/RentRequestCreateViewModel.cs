using System.Collections.Generic;
using Task3.Store.Models;

namespace Task3.ViewModels
{
    public class RentRequestCreateViewModel
    {
        public int? EventId { get; set; }
        public EventViewModel Event { get; set; }
        public int? SchoolId { get; set; }
        public SchoolViewModel School { get; set; }
        public Approval Approval { get; set; }
        public List<PlannedInventoryViewModel> PlannedInventories { get; set; }
        public List<RequestedInventoryViewModel> RequestedInventories { get; set; } // type to quantity in the original
    }
}
