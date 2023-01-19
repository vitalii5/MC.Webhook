namespace CqrsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DomainEvents", "MovieId1", c => c.Guid());
            AddColumn("dbo.DomainEvents", "ReleaseDate1", c => c.DateTime());
            AddColumn("dbo.DomainEvents", "MovieId2", c => c.Guid());
            AddColumn("dbo.DomainEvents", "RunningTimeMinutes1", c => c.Int());
            AddColumn("dbo.DomainEvents", "MovieId3", c => c.Guid());
            AddColumn("dbo.DomainEvents", "Title1", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DomainEvents", "Title1");
            DropColumn("dbo.DomainEvents", "MovieId3");
            DropColumn("dbo.DomainEvents", "RunningTimeMinutes1");
            DropColumn("dbo.DomainEvents", "MovieId2");
            DropColumn("dbo.DomainEvents", "ReleaseDate1");
            DropColumn("dbo.DomainEvents", "MovieId1");
        }
    }
}
