namespace ENGrupMimarlikIsparta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hakkimizda : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Detaylars",
                c => new
                    {
                        DetayID = c.Int(nullable: false, identity: true),
                        Fotograf = c.String(),
                        Baslik = c.String(),
                        Aciklama = c.String(),
                    })
                .PrimaryKey(t => t.DetayID);
            
            CreateTable(
                "dbo.Hakkimizdas",
                c => new
                    {
                        HakkimizdaID = c.Int(nullable: false, identity: true),
                        FirmaAdi = c.String(),
                        Slogan = c.String(),
                    })
                .PrimaryKey(t => t.HakkimizdaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Hakkimizdas");
            DropTable("dbo.Detaylars");
        }
    }
}
