namespace ENGrupMimarlikIsparta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loginOzellik : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        LoginID = c.Int(nullable: false, identity: true),
                        backgroundUrl = c.String(),
                        facebookAdresi = c.String(),
                        twitterAdresi = c.String(),
                        linkedinAdresi = c.String(),
                    })
                .PrimaryKey(t => t.LoginID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Logins");
        }
    }
}
