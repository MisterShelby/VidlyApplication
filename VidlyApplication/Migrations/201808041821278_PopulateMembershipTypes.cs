namespace VidlyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "SighUpFee", c => c.Short(nullable: false));
            DropColumn("dbo.MembershipTypes", "SighUpFree");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "SighUpFree", c => c.Short(nullable: false));
            DropColumn("dbo.MembershipTypes", "SighUpFee");
        }
    }
}
