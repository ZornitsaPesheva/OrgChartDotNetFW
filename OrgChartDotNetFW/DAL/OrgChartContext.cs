using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using OrgChartDotNetFW.Models;

namespace OrgChartDotNetFW.DAL
{
    public class OrgChartContext : DbContext
    {
        public OrgChartContext() : base("OrgChartContext")
        {

        }

        public DbSet<Node> Nodes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}