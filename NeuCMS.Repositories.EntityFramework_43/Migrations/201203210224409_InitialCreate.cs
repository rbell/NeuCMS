namespace NeuCMS.Repositories.EntityFramework_43.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "DimensionValues",
                c => new
                    {
                        DimensionValueId = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        DimensionDefinition_DimensionDefinitionId = c.String(maxLength: 128),
                        Content_ContentId = c.Int(),
                    })
                .PrimaryKey(t => t.DimensionValueId)
                .ForeignKey("DimensionDefinitions", t => t.DimensionDefinition_DimensionDefinitionId)
                .ForeignKey("Contents", t => t.Content_ContentId)
                .Index(t => t.DimensionDefinition_DimensionDefinitionId)
                .Index(t => t.Content_ContentId);
            
            CreateTable(
                "DimensionDefinitions",
                c => new
                    {
                        DimensionDefinitionId = c.String(nullable: false, maxLength: 128),
                        NamespaceId = c.String(),
                        DimensionName = c.String(),
                        NameSpace_NameSpaceId = c.Int(),
                    })
                .PrimaryKey(t => t.DimensionDefinitionId)
                .ForeignKey("NameSpaces", t => t.NameSpace_NameSpaceId)
                .Index(t => t.NameSpace_NameSpaceId);
            
            CreateTable(
                "NameSpaces",
                c => new
                    {
                        NameSpaceId = c.Int(nullable: false, identity: true),
                        NamespaceDefinitionId = c.String(),
                        NameSpaceName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.NameSpaceId);
            
            CreateTable(
                "Views",
                c => new
                    {
                        ViewId = c.Int(nullable: false, identity: true),
                        NameSpaceId = c.Int(nullable: false),
                        ViewName = c.String(),
                        ElementContentDefinition_ContentDefinitionId = c.Int(),
                        MediaContentDefinition_ContentDefinitionId = c.Int(),
                    })
                .PrimaryKey(t => t.ViewId)
                .ForeignKey("NameSpaces", t => t.NameSpaceId, cascadeDelete: true)
                .ForeignKey("ContentDefinitions", t => t.ElementContentDefinition_ContentDefinitionId)
                .ForeignKey("ContentDefinitions", t => t.MediaContentDefinition_ContentDefinitionId)
                .Index(t => t.NameSpaceId)
                .Index(t => t.ElementContentDefinition_ContentDefinitionId)
                .Index(t => t.MediaContentDefinition_ContentDefinitionId);
            
            CreateTable(
                "ContentMetadataValues",
                c => new
                    {
                        ContentMetadataValueId = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        MetaDataDefinition_ContentMetadataDefinitionId = c.Int(),
                        Content_ContentId = c.Int(),
                    })
                .PrimaryKey(t => t.ContentMetadataValueId)
                .ForeignKey("ContentMetadataDefinitions", t => t.MetaDataDefinition_ContentMetadataDefinitionId)
                .ForeignKey("Contents", t => t.Content_ContentId)
                .Index(t => t.MetaDataDefinition_ContentMetadataDefinitionId)
                .Index(t => t.Content_ContentId);
            
            CreateTable(
                "ContentMetadataDefinitions",
                c => new
                    {
                        ContentMetadataDefinitionId = c.Int(nullable: false, identity: true),
                        ContentDefinitionId = c.Int(nullable: false),
                        MetadataName = c.String(),
                    })
                .PrimaryKey(t => t.ContentMetadataDefinitionId)
                .ForeignKey("ContentDefinitions", t => t.ContentDefinitionId, cascadeDelete: true)
                .Index(t => t.ContentDefinitionId);
            
            CreateTable(
                "ContentDefinitions",
                c => new
                    {
                        ContentDefinitionId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContentType = c.Int(),
                        AvailableOnAllViews = c.Boolean(),
                        AvailableOnAllViews1 = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        DigitalAssetDefinition_ContentDefinitionId = c.Int(),
                    })
                .PrimaryKey(t => t.ContentDefinitionId)
                .ForeignKey("ContentDefinitions", t => t.DigitalAssetDefinition_ContentDefinitionId)
                .Index(t => t.DigitalAssetDefinition_ContentDefinitionId);
            
            CreateTable(
                "Contents",
                c => new
                    {
                        ContentId = c.Int(nullable: false, identity: true),
                        MediaContentDefinitionId = c.Int(),
                        ContentElementDefinitionId = c.String(),
                        Content = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        MediaContentDefinition_ContentDefinitionId = c.Int(),
                        DigitalAsset_DigitalAssetId = c.Int(),
                        ContentElementDefinition_ContentDefinitionId = c.Int(),
                    })
                .PrimaryKey(t => t.ContentId)
                .ForeignKey("ContentDefinitions", t => t.MediaContentDefinition_ContentDefinitionId)
                .ForeignKey("DigitalAssets", t => t.DigitalAsset_DigitalAssetId)
                .ForeignKey("ContentDefinitions", t => t.ContentElementDefinition_ContentDefinitionId)
                .Index(t => t.MediaContentDefinition_ContentDefinitionId)
                .Index(t => t.DigitalAsset_DigitalAssetId)
                .Index(t => t.ContentElementDefinition_ContentDefinitionId);
            
            CreateTable(
                "DigitalAssets",
                c => new
                    {
                        DigitalAssetId = c.Int(nullable: false, identity: true),
                        DigitalAssetDefinition_ContentDefinitionId = c.Int(),
                    })
                .PrimaryKey(t => t.DigitalAssetId)
                .ForeignKey("ContentDefinitions", t => t.DigitalAssetDefinition_ContentDefinitionId)
                .Index(t => t.DigitalAssetDefinition_ContentDefinitionId);
            
        }
        
        public override void Down()
        {
            DropIndex("DigitalAssets", new[] { "DigitalAssetDefinition_ContentDefinitionId" });
            DropIndex("Contents", new[] { "ContentElementDefinition_ContentDefinitionId" });
            DropIndex("Contents", new[] { "DigitalAsset_DigitalAssetId" });
            DropIndex("Contents", new[] { "MediaContentDefinition_ContentDefinitionId" });
            DropIndex("ContentDefinitions", new[] { "DigitalAssetDefinition_ContentDefinitionId" });
            DropIndex("ContentMetadataDefinitions", new[] { "ContentDefinitionId" });
            DropIndex("ContentMetadataValues", new[] { "Content_ContentId" });
            DropIndex("ContentMetadataValues", new[] { "MetaDataDefinition_ContentMetadataDefinitionId" });
            DropIndex("Views", new[] { "MediaContentDefinition_ContentDefinitionId" });
            DropIndex("Views", new[] { "ElementContentDefinition_ContentDefinitionId" });
            DropIndex("Views", new[] { "NameSpaceId" });
            DropIndex("DimensionDefinitions", new[] { "NameSpace_NameSpaceId" });
            DropIndex("DimensionValues", new[] { "Content_ContentId" });
            DropIndex("DimensionValues", new[] { "DimensionDefinition_DimensionDefinitionId" });
            DropForeignKey("DigitalAssets", "DigitalAssetDefinition_ContentDefinitionId", "ContentDefinitions");
            DropForeignKey("Contents", "ContentElementDefinition_ContentDefinitionId", "ContentDefinitions");
            DropForeignKey("Contents", "DigitalAsset_DigitalAssetId", "DigitalAssets");
            DropForeignKey("Contents", "MediaContentDefinition_ContentDefinitionId", "ContentDefinitions");
            DropForeignKey("ContentDefinitions", "DigitalAssetDefinition_ContentDefinitionId", "ContentDefinitions");
            DropForeignKey("ContentMetadataDefinitions", "ContentDefinitionId", "ContentDefinitions");
            DropForeignKey("ContentMetadataValues", "Content_ContentId", "Contents");
            DropForeignKey("ContentMetadataValues", "MetaDataDefinition_ContentMetadataDefinitionId", "ContentMetadataDefinitions");
            DropForeignKey("Views", "MediaContentDefinition_ContentDefinitionId", "ContentDefinitions");
            DropForeignKey("Views", "ElementContentDefinition_ContentDefinitionId", "ContentDefinitions");
            DropForeignKey("Views", "NameSpaceId", "NameSpaces");
            DropForeignKey("DimensionDefinitions", "NameSpace_NameSpaceId", "NameSpaces");
            DropForeignKey("DimensionValues", "Content_ContentId", "Contents");
            DropForeignKey("DimensionValues", "DimensionDefinition_DimensionDefinitionId", "DimensionDefinitions");
            DropTable("DigitalAssets");
            DropTable("Contents");
            DropTable("ContentDefinitions");
            DropTable("ContentMetadataDefinitions");
            DropTable("ContentMetadataValues");
            DropTable("Views");
            DropTable("NameSpaces");
            DropTable("DimensionDefinitions");
            DropTable("DimensionValues");
        }
    }
}
