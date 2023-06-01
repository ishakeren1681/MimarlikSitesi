namespace ENGrupMimarlikIsparta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iletisimbilgileri : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IletisimBilgileris",
                c => new
                    {
                        IletisimID = c.Int(nullable: false, identity: true),
                        Fotograf = c.String(),
                        Adres = c.String(),
                        Email = c.String(),
                        TelefonNumarasi = c.String(),
                    })
                .PrimaryKey(t => t.IletisimID);
            
            DropTable("dbo.Anasayfas");
            DropTable("dbo.Hakkimizdas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Hakkimizdas",
                c => new
                    {
                        HakkimizdaID = c.Int(nullable: false, identity: true),
                        FirmaAdi = c.String(),
                        Slogan = c.String(),
                    })
                .PrimaryKey(t => t.HakkimizdaID);
            
            CreateTable(
                "dbo.Anasayfas",
                c => new
                    {
                        AnasayfaID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.AnasayfaID);
            
            DropTable("dbo.IletisimBilgileris");
        }
    }
}
