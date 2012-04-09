namespace NeuCMS.Repositories.EntityFramework.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddDigitalAssetData : DbMigration
    {
        public override void Up()
        {
            AddColumn("DigitalAssets", "Data", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("DigitalAssets", "Data");
        }
    }
}
