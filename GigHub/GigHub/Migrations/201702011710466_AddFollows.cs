namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollows : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Follows",
                c => new
                    {
                        FollowerId = c.String(nullable: false, maxLength: 128),
                        FollowedId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.FollowedId })
                .ForeignKey("dbo.AspNetUsers", t => t.FollowedId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.FollowerId)
                .Index(t => t.FollowerId)
                .Index(t => t.FollowedId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Follows", "FollowerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Follows", "FollowedId", "dbo.AspNetUsers");
            DropIndex("dbo.Follows", new[] { "FollowedId" });
            DropIndex("dbo.Follows", new[] { "FollowerId" });
            DropTable("dbo.Follows");
        }
    }
}
