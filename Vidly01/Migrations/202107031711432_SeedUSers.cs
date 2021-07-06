namespace Vidly01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUSers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f1f1dd5d-1041-417f-8ba0-538a98c96fb7', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c1fad382-3df7-4f12-84b2-f452104fe0c5', N'admin1@vidly.com', 0, N'AHiD0MXnJI/WclPY2Zo3EpItvhGjQbhCj1mT7NIntSgR7klkZn26W30RMNzpm/VInQ==', N'6cfe56a3-ef67-4b5b-b17b-94945b967774', NULL, 0, 0, NULL, 1, 0, N'admin1@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cd32b609-e67e-4d2f-85e9-778987bd6c48', N'guests@vidly.com', 0, N'AIFn9V1/QbMp4OzN59HDCZStd2RnBH7O9INurU9Oehu4LipWhXK3FwZ97TslxWY6hg==', N'0fa2da97-8c46-4105-925e-f3eed3230166', NULL, 0, 0, NULL, 1, 0, N'guests@vidly.com')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c1fad382-3df7-4f12-84b2-f452104fe0c5', N'f1f1dd5d-1041-417f-8ba0-538a98c96fb7')

");
        }
        
        public override void Down()
        {
        }
    }
}
