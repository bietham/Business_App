using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using Task3.Store.Models;

namespace Task3.ViewModels
{
    public class EventViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public IEnumerable<PlannedInventory> PlannedInventories { get; set; }
    }
}
