// <auto-generated />
namespace NeuCMS.Repositories.EntityFramework.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    
    public sealed partial class ChangeDigitalAssetContentTypeToString : IMigrationMetadata
    {
        string IMigrationMetadata.Id
        {
            get { return "201204090230511_ChangeDigitalAssetContentTypeToString"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return "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"; }
        }
    }
}
