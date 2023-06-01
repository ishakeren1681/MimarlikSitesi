namespace ENGrupMimarlikIsparta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sayfalar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sayfalars",
                c => new
                    {
                        SayfaID = c.Int(nullable: false, identity: true),
                        FirmaAdi = c.String(),
                        Slogan = c.String(),
                        SayfaAdi = c.String(),
                    })
                .PrimaryKey(t => t.SayfaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sayfalars");
        }
    }
}
