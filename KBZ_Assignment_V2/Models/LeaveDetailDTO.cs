using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KBZ_Assignment_V2.Models
{
    public class LeaveDetailDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }
        public string EmployeeName { get; set; }
    }
}