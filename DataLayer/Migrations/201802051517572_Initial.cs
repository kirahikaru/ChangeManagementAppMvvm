namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActivityType",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(nullable: false, maxLength: 10, unicode: false),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CrtUsrName = c.String(nullable: false, maxLength: 50, unicode: false),
                        CrtDateTime = c.DateTime(nullable: false),
                        MdfUsrName = c.String(nullable: false, maxLength: 50, unicode: false),
                        MdfDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChangeRequestActivity",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ActivityTypeId = c.Guid(),
                        ChangeRequestId = c.Guid(nullable: false),
                        Remark = c.String(maxLength: 500),
                        UserId = c.String(maxLength: 20, unicode: false),
                        Username = c.String(maxLength: 50, unicode: false),
                        IsDeleted = c.Boolean(nullable: false),
                        SysTimestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActivityType", t => t.ActivityTypeId)
                .ForeignKey("dbo.ChangeRequest", t => t.ChangeRequestId, cascadeDelete: true)
                .Index(t => t.ActivityTypeId)
                .Index(t => t.ChangeRequestId);
            
            CreateTable(
                "dbo.ChangeRequest",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ChgReqID = c.String(nullable: false, maxLength: 20, unicode: false),
                        RemedyForceId = c.String(nullable: false, maxLength: 20, unicode: false),
                        Title = c.String(nullable: false, maxLength: 255, unicode: false),
                        Justification = c.String(maxLength: 1000),
                        Detail = c.String(maxLength: 1000),
                        Priority = c.String(maxLength: 10, unicode: false),
                        RequestDate = c.DateTime(),
                        ReceivedDate = c.DateTime(),
                        TargetCompleteDate = c.DateTime(),
                        TargetUatDate = c.DateTime(),
                        ActualCompleteDate = c.DateTime(),
                        ActualUatDate = c.DateTime(),
                        CloseDate = c.DateTime(),
                        WorkUnit = c.String(maxLength: 10, unicode: false),
                        Remark = c.String(maxLength: 500, unicode: false),
                        Status = c.String(maxLength: 50, unicode: false),
                        PclaAppSysId = c.Guid(),
                        ChangeTypeId = c.Guid(),
                        RequestorId = c.Guid(),
                        ITBusnAnalystId = c.Guid(),
                        IsDeleted = c.Boolean(nullable: false),
                        CrtUsrName = c.String(nullable: false, maxLength: 50, unicode: false),
                        CrtDateTime = c.DateTime(nullable: false),
                        MdfUsrName = c.String(nullable: false, maxLength: 50, unicode: false),
                        MdfDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChangeType", t => t.ChangeTypeId)
                .ForeignKey("dbo.Employee", t => t.ITBusnAnalystId)
                .ForeignKey("dbo.PclaAppSys", t => t.PclaAppSysId, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.RequestorId)
                .Index(t => t.PclaAppSysId)
                .Index(t => t.ChangeTypeId)
                .Index(t => t.RequestorId)
                .Index(t => t.ITBusnAnalystId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EmployeeID = c.String(nullable: false, maxLength: 10, unicode: false),
                        GivenName = c.String(nullable: false, maxLength: 100),
                        Surname = c.String(nullable: false, maxLength: 100),
                        Fullname = c.String(maxLength: 200),
                        PositionTitle = c.String(maxLength: 150, unicode: false),
                        Department = c.String(maxLength: 150, unicode: false),
                        Function = c.String(maxLength: 150, unicode: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CrtUsrName = c.String(nullable: false, maxLength: 50, unicode: false),
                        CrtDateTime = c.DateTime(nullable: false),
                        MdfUsrName = c.String(nullable: false, maxLength: 50, unicode: false),
                        MdfDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChangeRequestBusnReqSpec",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ChangeRequestId = c.Guid(nullable: false),
                        RequirementId = c.String(maxLength: 500, unicode: false),
                        RequirementDesc = c.String(),
                        Priority = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        CrtUsrName = c.String(nullable: false, maxLength: 50),
                        CrtDateTime = c.DateTime(nullable: false),
                        MdfUsrName = c.String(nullable: false, maxLength: 50),
                        MdfDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChangeRequest", t => t.ChangeRequestId, cascadeDelete: true)
                .Index(t => t.ChangeRequestId);
            
            CreateTable(
                "dbo.ChangeType",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(nullable: false, maxLength: 10, unicode: false),
                        Name = c.String(nullable: false, maxLength: 150, unicode: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CrtUsrName = c.String(nullable: false, maxLength: 50, unicode: false),
                        CrtDateTime = c.DateTime(nullable: false),
                        MdfUsrName = c.String(nullable: false, maxLength: 50, unicode: false),
                        MdfDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PclaAppSys",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(nullable: false, maxLength: 20, unicode: false),
                        Name = c.String(nullable: false, maxLength: 150, unicode: false),
                        TypeCode = c.String(maxLength: 20, unicode: false),
                        LatestVersion = c.String(nullable: false, maxLength: 10, unicode: false),
                        Remark = c.String(maxLength: 500),
                        IsDeleted = c.Boolean(nullable: false),
                        CrtUsrName = c.String(nullable: false, maxLength: 50, unicode: false),
                        CrtDateTime = c.DateTime(nullable: false),
                        MdfUsrName = c.String(nullable: false, maxLength: 50, unicode: false),
                        MdfDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChangeRequestDoc",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CrtDateTime = c.DateTime(nullable: false),
                        CrtUsrName = c.String(nullable: false, maxLength: 50),
                        MdfUsrName = c.String(nullable: false, maxLength: 50),
                        DocCode = c.String(nullable: false, maxLength: 10, unicode: false),
                        DocName = c.String(maxLength: 100, unicode: false),
                        DocOwner = c.String(maxLength: 100, unicode: false),
                        DocPath = c.String(maxLength: 500, unicode: false),
                        ChgReqId = c.Guid(),
                        MdfDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChangeRequest", t => t.ChgReqId, cascadeDelete: true)
                .Index(t => t.ChgReqId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 20, unicode: false),
                        Username = c.String(nullable: false, maxLength: 100, unicode: false),
                        Password = c.String(maxLength: 50, unicode: false),
                        IsActiveDir = c.Boolean(),
                        IsDeleted = c.Boolean(nullable: false),
                        CrtUsrName = c.String(nullable: false, maxLength: 50),
                        CrtDateTime = c.DateTime(nullable: false),
                        MdfUsrName = c.String(nullable: false, maxLength: 50),
                        MdfDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChangeRequestAssignedDeveloper",
                c => new
                    {
                        ChangeRequestId = c.Guid(nullable: false),
                        EmployeeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ChangeRequestId, t.EmployeeId })
                .ForeignKey("dbo.ChangeRequest", t => t.ChangeRequestId, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.ChangeRequestId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChangeRequestDoc", "ChgReqId", "dbo.ChangeRequest");
            DropForeignKey("dbo.ChangeRequest", "RequestorId", "dbo.Employee");
            DropForeignKey("dbo.ChangeRequest", "PclaAppSysId", "dbo.PclaAppSys");
            DropForeignKey("dbo.ChangeRequest", "ITBusnAnalystId", "dbo.Employee");
            DropForeignKey("dbo.ChangeRequest", "ChangeTypeId", "dbo.ChangeType");
            DropForeignKey("dbo.ChangeRequestBusnReqSpec", "ChangeRequestId", "dbo.ChangeRequest");
            DropForeignKey("dbo.ChangeRequestAssignedDeveloper", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.ChangeRequestAssignedDeveloper", "ChangeRequestId", "dbo.ChangeRequest");
            DropForeignKey("dbo.ChangeRequestActivity", "ChangeRequestId", "dbo.ChangeRequest");
            DropForeignKey("dbo.ChangeRequestActivity", "ActivityTypeId", "dbo.ActivityType");
            DropIndex("dbo.ChangeRequestAssignedDeveloper", new[] { "EmployeeId" });
            DropIndex("dbo.ChangeRequestAssignedDeveloper", new[] { "ChangeRequestId" });
            DropIndex("dbo.ChangeRequestDoc", new[] { "ChgReqId" });
            DropIndex("dbo.ChangeRequestBusnReqSpec", new[] { "ChangeRequestId" });
            DropIndex("dbo.ChangeRequest", new[] { "ITBusnAnalystId" });
            DropIndex("dbo.ChangeRequest", new[] { "RequestorId" });
            DropIndex("dbo.ChangeRequest", new[] { "ChangeTypeId" });
            DropIndex("dbo.ChangeRequest", new[] { "PclaAppSysId" });
            DropIndex("dbo.ChangeRequestActivity", new[] { "ChangeRequestId" });
            DropIndex("dbo.ChangeRequestActivity", new[] { "ActivityTypeId" });
            DropTable("dbo.ChangeRequestAssignedDeveloper");
            DropTable("dbo.User");
            DropTable("dbo.ChangeRequestDoc");
            DropTable("dbo.PclaAppSys");
            DropTable("dbo.ChangeType");
            DropTable("dbo.ChangeRequestBusnReqSpec");
            DropTable("dbo.Employee");
            DropTable("dbo.ChangeRequest");
            DropTable("dbo.ChangeRequestActivity");
            DropTable("dbo.ActivityType");
        }
    }
}
