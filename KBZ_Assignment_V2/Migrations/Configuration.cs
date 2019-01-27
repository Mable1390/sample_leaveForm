namespace KBZ_Assignment_V2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using KBZ_Assignment_V2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<KBZ_Assignment_V2.Models.KBZ_Assignment_V2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KBZ_Assignment_V2.Models.KBZ_Assignment_V2Context context)
        {
            context.Employees.AddOrUpdate(x => x.Id,
                new Employee() { Id = 1, Name = "May", Position = "Programmer"},
                new Employee() { Id = 2, Name = "Phyoe", Position = "Developer" },
                new Employee() { Id = 3, Name = "Thu", Position = "Designer" }
            );

            context.Leaves.AddOrUpdate(x => x.Id,
                new Leave() { Id = 1, Title = "Anual Leaves", EmployeeId = 1, Reason = "To Back to Home Town.", Date = new DateTime(2018, 10, 12) },
                new Leave() { Id = 2, Title = "Anual Leaves", EmployeeId = 1, Reason = "To Back to Home Town.", Date = new DateTime(2018, 12, 30) },
                new Leave() { Id = 3, Title = "Anual Leaves", EmployeeId = 3, Reason = "To Back to Home Town.", Date = new DateTime(2019, 1, 21) }
            );

            context.Holidays.AddOrUpdate(x => x.Id,                
                new Holiday() { Id = 1, Title = "Independence Day", Date = new DateTime(2019, 1, 4) },
                new Holiday() { Id = 1, Title = "Public Holiday", Date = new DateTime(2019, 2, 12) }
            );
        }
    }
}
