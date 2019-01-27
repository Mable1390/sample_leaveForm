using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KBZ_Assignment_V2.Models
{
    public class KBZ_Assignment_V2Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public KBZ_Assignment_V2Context() : base("name=KBZ_Assignment_V2Context")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<KBZ_Assignment_V2.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<KBZ_Assignment_V2.Models.Holiday> Holidays { get; set; }

        public System.Data.Entity.DbSet<KBZ_Assignment_V2.Models.Leave> Leaves { get; set; }
    }
}
