namespace VidlyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'aeaa7c40-cc49-4d3d-a7d4-6a9d5f357298', N'guest@vidly.com', 0, N'AHa5ffWatZaokolt9tEVUnU74tMEjyo77DqgWxy/qFHOjFSTEo6G3c7jz7T8MCBuog==', N'094fee34-bcdc-47cd-aadf-9ee0faf8cd08', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e8e3c9cf-dec1-489f-8913-05ab734b9284', N'admin@vidly.com', 0, N'AHxSQKgV8qZIa3h3IHXF1iojPxesiDzXnxNFdt70923lkTiKgytMi4UCMuQN9r/zYQ==', N'95ae09f4-c162-40b2-abb9-7aef8fd4daa3', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'610c8196-19aa-4655-906b-bd862c9555c0', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e8e3c9cf-dec1-489f-8913-05ab734b9284', N'610c8196-19aa-4655-906b-bd862c9555c0')

");
        }
        
        public override void Down()
        {
        }
    }
}
