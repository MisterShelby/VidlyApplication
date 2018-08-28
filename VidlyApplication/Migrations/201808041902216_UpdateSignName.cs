namespace VidlyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSignName : DbMigration
    {
        public override void Up()
        {
            RenameColumn("MembershipTypes", "SighUpFee", "SignUpFee");
        }
        
        public override void Down()
        {
            RenameColumn("MembershipTypes", "SignUpFee", "SighUpFee");
        }
    }
}
