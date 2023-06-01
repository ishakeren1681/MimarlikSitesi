namespace ENGrupMimarlikIsparta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminler : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        KullaniciAdi = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Sifre = c.Int(nullable: false),
                        SifreTekrar = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdminID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admins");
        }
    }
}
