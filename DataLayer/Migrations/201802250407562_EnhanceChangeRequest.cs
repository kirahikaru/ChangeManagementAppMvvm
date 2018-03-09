namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnhanceChangeRequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChangeRequest", "DevManday", c => c.Int());
            AddColumn("dbo.ChangeRequest", "DocManday", c => c.Int());
            AddColumn("dbo.ChangeRequest", "OthManday", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChangeRequest", "OthManday");
            DropColumn("dbo.ChangeRequest", "DocManday");
            DropColumn("dbo.ChangeRequest", "DevManday");
        }
    }
}
