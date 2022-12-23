using System.Collections.Generic;
using Task3.Store.Models;

namespace Task3.ViewModels
{
    public class RentRequestEditViewModel
    {
        public int Id { get; set; }
        public Approval Approval { get; set; }
        public List<AllocatedInventoryViewModel> AllocatedInventories { get; set; }
        public List<RequestedInventoryViewModel> RequestedInventories { get; set; } // type to quantity in the original
        public List<ReturnRequestViewModel> ReturnRequests { get; set; }
        public List<UnloadRequestViewModel> UnloadRequests { get; set; }
    }
}
