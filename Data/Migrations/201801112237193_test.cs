namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {

            
            
            
           
            
            CreateTable(
                "dbo.report",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Content = c.String(maxLength: 255, storeType: "nvarchar"),
                        subject = c.String(maxLength: 255, storeType: "nvarchar"),
                        name = c.String(maxLength: 255, storeType: "nvarchar"),
                        lastName = c.String(maxLength: 255, storeType: "nvarchar"),
                        vu = c.Int(nullable: false),
                        insured_id = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            

            
            
            
        }
        
        public override void Down()
        {
           
         
            DropTable("dbo.report");
            
        }
    }
}
