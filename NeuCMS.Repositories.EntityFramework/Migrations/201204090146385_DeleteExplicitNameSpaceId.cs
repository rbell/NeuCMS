namespace NeuCMS.Repositories.EntityFramework.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class DeleteExplicitNameSpaceId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Views", "NameSpaceId", "NameSpaces");
            DropIndex("Views", new[] { "NameSpaceId" });
            RenameColumn(table: "Views", name: "NameSpaceId", newName: "NameSpace_Id");
            AddForeignKey("Views", "NameSpace_Id", "NameSpaces", "Id");
            CreateIndex("Views", "NameSpace_Id");
        }
        
        public override void Down()
        {
            DropIndex("Views", new[] { "NameSpace_Id" });
            DropForeignKey("Views", "NameSpace_Id", "NameSpaces");
            RenameColumn(table: "Views", name: "NameSpace_Id", newName: "NameSpaceId");
            CreateIndex("Views", "NameSpaceId");
            AddForeignKey("Views", "NameSpaceId", "NameSpaces", "Id", cascadeDelete: true);
        }
    }
}
