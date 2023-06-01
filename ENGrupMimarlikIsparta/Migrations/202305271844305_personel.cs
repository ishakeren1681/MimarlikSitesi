namespace ENGrupMimarlikIsparta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class personel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personels",
                c => new
                    {
                        PersonelID = c.Int(nullable: false, identity: true),
                        Fotograf = c.String(),
                        Unvan = c.String(),
                        TelefonNumarasi = c.String(),
                    })
                .PrimaryKey(t => t.PersonelID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Personels");
        }
    }
}
