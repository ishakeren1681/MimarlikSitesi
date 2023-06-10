namespace ENGrupMimarlikIsparta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YUKLE : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        KullaniciAdi = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        YetkiStatusu = c.String(nullable: false),
                        Sifre = c.String(nullable: false),
                        SifreTekrar = c.String(),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.Detaylars",
                c => new
                    {
                        DetayID = c.Int(nullable: false, identity: true),
                        HangiSayfa = c.String(),
                        Fotograf = c.String(),
                        Baslik = c.String(),
                        Aciklama = c.String(),
                        Yonu = c.String(),
                    })
                .PrimaryKey(t => t.DetayID);
            
            CreateTable(
                "dbo.EPostas",
                c => new
                    {
                        MesajID = c.Int(nullable: false, identity: true),
                        Gonderen = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Konu = c.String(nullable: false),
                        Tarih = c.DateTime(nullable: false),
                        MesajDetay = c.String(),
                        TelefonNumarasi = c.String(),
                        MesajStatusu = c.String(),
                    })
                .PrimaryKey(t => t.MesajID);
            
            CreateTable(
                "dbo.Hizmetlerimizs",
                c => new
                    {
                        HizmetID = c.Int(nullable: false, identity: true),
                        Hizmet = c.String(),
                    })
                .PrimaryKey(t => t.HizmetID);
            
            CreateTable(
                "dbo.IletisimBilgileris",
                c => new
                    {
                        IletisimID = c.Int(nullable: false, identity: true),
                        Fotograf = c.String(),
                        Adres = c.String(),
                        Email = c.String(),
                        TelefonNumarasi_1 = c.String(),
                        TelefonNumarasi_2 = c.String(),
                        FirmaLogosu = c.String(),
                    })
                .PrimaryKey(t => t.IletisimID);
            
            CreateTable(
                "dbo.Personels",
                c => new
                    {
                        PersonelID = c.Int(nullable: false, identity: true),
                        AdSoyad = c.String(),
                        Fotograf = c.String(),
                        Unvan = c.String(),
                        TelefonNumarasi = c.String(),
                    })
                .PrimaryKey(t => t.PersonelID);
            
            CreateTable(
                "dbo.SosyalMedyaAyarlars",
                c => new
                    {
                        LoginID = c.Int(nullable: false, identity: true),
                        facebookAdresi = c.String(),
                        twitterAdresi = c.String(),
                        linkedinAdresi = c.String(),
                        instagramAdresi = c.String(),
                    })
                .PrimaryKey(t => t.LoginID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SosyalMedyaAyarlars");
            DropTable("dbo.Personels");
            DropTable("dbo.IletisimBilgileris");
            DropTable("dbo.Hizmetlerimizs");
            DropTable("dbo.EPostas");
            DropTable("dbo.Detaylars");
            DropTable("dbo.Admins");
        }
    }
}
