using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KBZ_Assignment_V2.Models
{
    public class LeaveDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string EmployeeName { get; set; }
    }
}