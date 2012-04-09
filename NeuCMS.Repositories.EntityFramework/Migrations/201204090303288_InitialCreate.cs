namespace NeuCMS.Repositories.EntityFramework.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "ContentDefinitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AvailableOnAllViews = c.Boolean(nullable: false),
                        NameSpace_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("NameSpaces", t => t.NameSpace_Id)
                .Index(t => t.NameSpace_Id);
            
            CreateTable(
                "NameSpaces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameSpaceName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "DimensionDefinitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DimensionName = c.String(),
                        NameSpace_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("NameSpaces", t => t.NameSpace_Id)
                .Index(t => t.NameSpace_Id);
            
            CreateTable(
                "Views",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ViewName = c.String(),
                        NameSpace_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("NameSpaces", t => t.NameSpace_Id)
                .Index(t => t.NameSpace_Id);
            
            CreateTable(
                "ContentMetadataDefinitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContentDefinitionId = c.Int(nullable: false),
                        MetadataName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ContentDefinitions", t => t.ContentDefinitionId, cascadeDelete: true)
                .Index(t => t.ContentDefinitionId);
            
            CreateTable(
                "DimensionValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        DimensionDefinition_Id = c.Int(),
                        Content_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("DimensionDefinitions", t => t.DimensionDefinition_Id)
                .ForeignKey("Contents", t => t.Content_Id)
                .Index(t => t.DimensionDefinition_Id)
                .Index(t => t.Content_Id);
            
            CreateTable(
                "ContentMetadataValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        MetaDataDefinition_Id = c.Int(),
                        Content_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ContentMetadataDefinitions", t => t.MetaDataDefinition_Id)
                .ForeignKey("Contents", t => t.Content_Id)
                .Index(t => t.MetaDataDefinition_Id)
                .Index(t => t.Content_Id);
            
            CreateTable(
                "Contents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        ContentElementDefinition_Id = c.Int(),
                        DigitalAsset_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ContentDefinitions", t => t.ContentElementDefinition_Id)
                .ForeignKey("DigitalAssets", t => t.DigitalAsset_Id)
                .Index(t => t.ContentElementDefinition_Id)
                .Index(t => t.DigitalAsset_Id);
            
            CreateTable(
                "DigitalAssets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContentType = c.String(),
                        Data = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "ViewContentDefinitions",
                c => new
                    {
                        ContentDefinition_Id = c.Int(nullable: false),
                        View_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ContentDefinition_Id, t.View_Id })
                .ForeignKey("ContentDefinitions", t => t.ContentDefinition_Id, cascadeDelete: true)
                .ForeignKey("Views", t => t.View_Id, cascadeDelete: true)
                .Index(t => t.ContentDefinition_Id)
                .Index(t => t.View_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("ViewContentDefinitions", new[] { "View_Id" });
            DropIndex("ViewContentDefinitions", new[] { "ContentDefinition_Id" });
            DropIndex("Contents", new[] { "DigitalAsset_Id" });
            DropIndex("Contents", new[] { "ContentElementDefinition_Id" });
            DropIndex("ContentMetadataValues", new[] { "Content_Id" });
            DropIndex("ContentMetadataValues", new[] { "MetaDataDefinition_Id" });
            DropIndex("DimensionValues", new[] { "Content_Id" });
            DropIndex("DimensionValues", new[] { "DimensionDefinition_Id" });
            DropIndex("ContentMetadataDefinitions", new[] { "ContentDefinitionId" });
            DropIndex("Views", new[] { "NameSpace_Id" });
            DropIndex("DimensionDefinitions", new[] { "NameSpace_Id" });
            DropIndex("ContentDefinitions", new[] { "NameSpace_Id" });
            DropForeignKey("ViewContentDefinitions", "View_Id", "Views");
            DropForeignKey("ViewContentDefinitions", "ContentDefinition_Id", "ContentDefinitions");
            DropForeignKey("Contents", "DigitalAsset_Id", "DigitalAssets");
            DropForeignKey("Contents", "ContentElementDefinition_Id", "ContentDefinitions");
            DropForeignKey("ContentMetadataValues", "Content_Id", "Contents");
            DropForeignKey("ContentMetadataValues", "MetaDataDefinition_Id", "ContentMetadataDefinitions");
            DropForeignKey("DimensionValues", "Content_Id", "Contents");
            DropForeignKey("DimensionValues", "DimensionDefinition_Id", "DimensionDefinitions");
            DropForeignKey("ContentMetadataDefinitions", "ContentDefinitionId", "ContentDefinitions");
            DropForeignKey("Views", "NameSpace_Id", "NameSpaces");
            DropForeignKey("DimensionDefinitions", "NameSpace_Id", "NameSpaces");
            DropForeignKey("ContentDefinitions", "NameSpace_Id", "NameSpaces");
            DropTable("ViewContentDefinitions");
            DropTable("DigitalAssets");
            DropTable("Contents");
            DropTable("ContentMetadataValues");
            DropTable("DimensionValues");
            DropTable("ContentMetadataDefinitions");
            DropTable("Views");
            DropTable("DimensionDefinitions");
            DropTable("NameSpaces");
            DropTable("ContentDefinitions");
        }
    }
}
