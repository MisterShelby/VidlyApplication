namespace VidlyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateValuesInMemberShipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes SET Name='Monthly' Where Id=2");
            Sql("Update MembershipTypes SET Name='Quarterly' Where Id=3");
            Sql("Update MembershipTypes SET Name='Annual' Where Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
