namespace VidlyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBirtdayInCustomerIvanSolomka : DbMigration
    {
        public override void Up()
        {
            Sql("Update Customers SET Birthday='01/23/1996' Where Id=1");
        }
        
        public override void Down()
        {
        }
    }
}
