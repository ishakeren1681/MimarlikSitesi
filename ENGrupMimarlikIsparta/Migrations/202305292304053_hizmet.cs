namespace ENGrupMimarlikIsparta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hizmet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hizmetlerimizs",
                c => new
                    {
                        HizmetID = c.Int(nullable: false, identity: true),
                        Hizmet = c.String(),
                    })
                .PrimaryKey(t => t.HizmetID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Hizmetlerimizs");
        }
    }
}
