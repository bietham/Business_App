using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using Task3.Store.Models;

namespace Task3.ViewModels.Store
{
    public class EventDeleteViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
