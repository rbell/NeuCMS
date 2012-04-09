namespace NeuCMS.Repositories.EntityFramework.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class DeleteExplicitNameSpaceId2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("DimensionDefinitions", "NamespaceId");
        }
        
        public override void Down()
        {
            AddColumn("DimensionDefinitions", "NamespaceId", c => c.String());
        }
    }
}
