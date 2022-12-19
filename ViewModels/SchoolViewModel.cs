using System.Collections.Generic;
using Task3.Store.Models;

namespace Task3.ViewModels

{
    public class SchoolViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Inventory> Inventories { get; set; }
        public List<RentRequest> RentRequests { get; set; }

    }
}
