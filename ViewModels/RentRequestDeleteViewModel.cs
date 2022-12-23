using Task3.Store.Models;

namespace Task3.ViewModels
{
    public class RentRequestDeleteViewModel
    {
        public int Id { get; set; }
        public EventViewModel Event { get; set; }
        public int? SchoolId { get; set; }
    }
}
