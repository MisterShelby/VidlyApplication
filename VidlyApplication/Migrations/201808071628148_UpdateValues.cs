namespace VidlyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateValues : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes SET Name='Pay as You Go' Where Id=1");

        }

        public override void Down()
        {
        }
    }
}
