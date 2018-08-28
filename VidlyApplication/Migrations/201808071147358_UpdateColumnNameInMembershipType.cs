namespace VidlyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateColumnNameInMembershipType : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MembershipTypes", "SignUpFee");
        }
        
        public override void Down()
        {
            
            DropColumn("dbo.MembershipTypes", "SignUpFee");
        }
    }
}
