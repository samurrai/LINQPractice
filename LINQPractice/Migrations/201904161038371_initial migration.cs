namespace LINQPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MusicalGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        SongDescription_Id = c.Guid(),
                        MusicalGroup_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SongDescriptions", t => t.SongDescription_Id)
                .ForeignKey("dbo.MusicalGroups", t => t.MusicalGroup_Id)
                .Index(t => t.SongDescription_Id)
                .Index(t => t.MusicalGroup_Id);
            
            CreateTable(
                "dbo.SongDescriptions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Lyrics = c.String(),
                        Time = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "MusicalGroup_Id", "dbo.MusicalGroups");
            DropForeignKey("dbo.Songs", "SongDescription_Id", "dbo.SongDescriptions");
            DropIndex("dbo.Songs", new[] { "MusicalGroup_Id" });
            DropIndex("dbo.Songs", new[] { "SongDescription_Id" });
            DropTable("dbo.SongDescriptions");
            DropTable("dbo.Songs");
            DropTable("dbo.MusicalGroups");
        }
    }
}
