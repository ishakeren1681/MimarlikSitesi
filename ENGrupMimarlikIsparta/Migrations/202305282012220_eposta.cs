namespace ENGrupMimarlikIsparta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eposta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.EPostas",
               c => new
               {
                   MesajID = c.Int(nullable: false, identity: true),
                   Gonderen = c.String(nullable: false),
                   Email = c.String(nullable: false),
                   Konu = c.String(nullable: false),
                   MesajDetay = c.String(nullable: false),
                   TelefonNumarasi = c.String(),
                   MesajStatusu = c.String(),
               })
               .PrimaryKey(t => t.MesajID);
        }
        
        public override void Down()
        {
            DropTable("dbo.EPostas");
        }
    }
}
