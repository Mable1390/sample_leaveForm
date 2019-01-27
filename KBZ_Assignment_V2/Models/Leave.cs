using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KBZ_Assignment_V2.Models
{
    public class Leave
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }        
        public DateTime Date { get; set; }
        public string Reason { get; set; }
        // Foreign Key & Navigation property
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}