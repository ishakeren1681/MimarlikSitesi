namespace ENGrupMimarlikIsparta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class detaylar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Detaylars", "Tarih", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Detaylars", "Tarih");
        }
    }
}
