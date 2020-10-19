namespace OrgChartDotNetFW.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using OrgChartDotNetFW.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<OrgChartDotNetFW.DAL.OrgChartContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "OrgChartDotNetFW.DAL.OrgChartContext";
        }

        protected override void Seed(OrgChartDotNetFW.DAL.OrgChartContext context)
        {
            context.Nodes.AddOrUpdate(x => x.id,
                 new Node(){ id = "top-management", tags = new string[] { "top-management" } },
                new Node() { id = "hr-team", pid = "top-management", tags = new string[] { "hr-team", "department" }, name = "HR department" },
                new Node() { id = "it-team", pid = "top-management", tags = new string[] { "it-team", "department" }, name = "IT department" },
                new Node() { id = "sales-team", pid = "top-management", tags = new string[] { "sales-team", "department" }, name = "Sales department" },

                new Node() { id = "1", stpid = "top-management", name = "Nicky Phillips", title = "CEO", img = "https://cdn.balkan.app/shared/1.jpg", tags = new string[] { "seo-menu" } },
                new Node() { id = "2", pid = "1", name = "Rowan Hall", title = "Shareholder (51%)", img = "https://cdn.balkan.app/shared/2.jpg", tags = new string[] { "menu-without-add" } },
                new Node() { id = "3", pid = "1", name = "Danni Anderson", title = "Shareholder (49%)", img = "https://cdn.balkan.app/shared/3.jpg", tags = new string[] { "menu-without-add" } },

                new Node() { id = "4", stpid = "hr-team", name = "Jordan Harris", title = "HR Manager", img = "https://cdn.balkan.app/shared/4.jpg" },
                new Node() { id = "5", pid = "4", name = "Emerson Adams", title = "Senior HR", img = "https://cdn.balkan.app/shared/5.jpg" },
                new Node() { id = "6", pid = "4", name = "Kai Morgan", title = "Junior HR", img = "https://cdn.balkan.app/shared/6.jpg" },

                new Node() { id = "7", stpid = "it-team", name = "Cory Robbins", title = "Core Team Lead", img = "https://cdn.balkan.app/shared/7.jpg" },
                new Node() { id = "8", pid = "7", name = "Billie Roach", title = "Backend Senior Developer", img = "https://cdn.balkan.app/shared/8.jpg" },
                new Node() { id = "9", pid = "7", name = "Maddox Hood", title = "C# Developer", img = "https://cdn.balkan.app/shared/9.jpg" },
                new Node() { id = "10", pid = "7", name = "Sam Tyson", title = "Backend Junior Developer", img = "https://cdn.balkan.app/shared/10.jpg" },

                new Node() { id = "11", stpid = "it-team", name = "Lynn Fleming", title = "UI Team Lead", img = "https://cdn.balkan.app/shared/11.jpg" },
                new Node() { id = "12", pid = "11", name = "Jo Baker", title = "JS Developer", img = "https://cdn.balkan.app/shared/12.jpg" },
                new Node() { id = "13", pid = "11", name = "Emerson Lewis", title = "Graphic Designer", img = "https://cdn.balkan.app/shared/13.jpg" },
                new Node() { id = "14", pid = "11", name = "Haiden Atkinson", title = "UX Expert", img = "https://cdn.balkan.app/shared/14.jpg" },
                new Node() { id = "15", stpid = "sales-team", name = "Tyler Chavez", title = "Sales Manager", img = "https://cdn.balkan.app/shared/15.jpg" },
                new Node() { id = "16", pid = "15", name = "Raylee Allen", title = "Sales", img = "https://cdn.balkan.app/shared/16.jpg" },
                new Node { id = "17", pid = "15", name = "Kris Horne", title = "Sales Guru", img = "https://cdn.balkan.app/shared/8.jpg" },
                new Node() { id = "18", pid = "top-management", name = "Leslie Mcclain", title = "Personal assistant", img = "https://cdn.balkan.app/shared/9.jpg", tags = new string[] { "assistant", "menu-without-add" } }

        //  This method will be called after migrating to the latest version.

        //  You can use the DbSet<T>.AddOrUpdate() helper extension method
        //  to avoid creating duplicate seed data.
            );
        }
    }
}
