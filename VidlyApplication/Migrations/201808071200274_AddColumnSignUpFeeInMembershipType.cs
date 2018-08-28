namespace VidlyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnSignUpFeeInMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("MembershipTypes", "SignUpFee",c=>c.Short(nullable:false));
           
        }
        
        public override void Down()
        {
        }
    }
}
