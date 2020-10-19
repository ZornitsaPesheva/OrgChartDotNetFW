namespace OrgChartDotNetFW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Node",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Pid = c.String(),
                        Stpid = c.String(),
                        Name = c.String(),
                        Title = c.String(),
                        Img = c.String(),
                        InternalTags = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Node");
        }
    }
}
