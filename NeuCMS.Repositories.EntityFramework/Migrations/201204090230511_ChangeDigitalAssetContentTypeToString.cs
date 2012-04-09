namespace NeuCMS.Repositories.EntityFramework.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDigitalAssetContentTypeToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("DigitalAssets", "ContentType", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("DigitalAssets", "ContentType", c => c.Int(nullable: false));
        }
    }
}
