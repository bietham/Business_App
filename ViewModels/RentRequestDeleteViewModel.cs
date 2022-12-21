using Task3.Store.Models;

namespace Task3.ViewModels
{
    public class RentRequestDeleteViewModel
    {
        public int Id { get; set; }
        public Event Event { get; set; }
        public int? SchoolId { get; set; }
    }
}
