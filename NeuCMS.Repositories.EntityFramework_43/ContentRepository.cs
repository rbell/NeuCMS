using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using NeuCMS.Core.Entities;
using NeuCMS.Core.Repositories;

namespace NeuCMS.Repositories.EntityFramework_43
{
    public class ContentRepository : DbContext, IContentRepository
    {
        public ContentRepository()
            : base("NeuCMSDB")
        {
        }

        public IDbSet<Content> Contents
        {
            get { return Set<Content>(); }
        }

        public IDbSet<DigitalAsset> DigitalAssets
        {
            get { return Set<DigitalAsset>(); }
        }

        public IDbSet<ContentDefinition> ContentDefinitions
        {
            get { return Set<ContentDefinition>(); }
        }

        public IDbSet<ContentMetadataValue> ContentMetadataValues
        {
            get { return Set<ContentMetadataValue>(); }
        }

        public IDbSet<ContentMetadataDefinition> ContentMetadataDefinitions
        {
            get { return Set<ContentMetadataDefinition>(); }
        }

        public IDbSet<DimensionValue> DimensionValues
        {
            get { return Set<DimensionValue>(); }
        }

        public IDbSet<DimensionDefinition> DimensionDefinitions
        {
            get { return Set<DimensionDefinition>(); }
        }

        public IDbSet<View> Views
        {
            get { return Set<View>(); }
        }

        public IDbSet<NameSpace> NameSpaces
        {
            get { return Set<NameSpace>(); }
        }


        //public DbSet<Content> Contents { get; set; }
        //public DbSet<DigitalAsset> DigitalAssets { get; set; }
        //public DbSet<ContentDefinition> ContentDefinitions { get; set; }
        //public DbSet<ContentMetadataValue> ContentMetadataValues { get; set; }
        //public DbSet<ContentMetadataDefinition> ContentMetadataDefinitions { get; set; }
        //public DbSet<DimensionValue> DimensionValues { get; set; }
        //public DbSet<DimensionDefinition> DimensionDefinitions { get; set; }
        //public DbSet<View> Views { get; set; }
        //public DbSet<NameSpace> NameSpaces { get; set; }

        public void Commit()
        {
            this.SaveChanges();
        }

    }
}