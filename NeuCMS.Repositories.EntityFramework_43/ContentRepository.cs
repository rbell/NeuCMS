using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using NeuCMS.Core.Entities;
using NeuCMS.Core.Repositories;

namespace NeuCMS.Repositories.EntityFramework_43
{
    public class ContentRepository : DbContext, IContentRepository
    {
        public ContentRepository()
        {
            ContentQueryResults = from content in Contents.OfType<ElementContent>()
                                  select new ContentQueryResult()
                                             {
                                                 Content = content.Content,
                                                 ContentKey = content.ContentElementDefinition.Name,
                                                 Id = content.Id
                                             };
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContentDefinition>()
                .HasMany(e => e.Views)
                .WithMany(e => e.ContentDefinitions)
                .Map(m =>
                         {
                             m.ToTable("ViewContentDefinitions");
                             m.MapLeftKey("View_Id");
                             m.MapRightKey("ContentDefinition_Id");
                         });
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

        public IQueryable<ContentQueryResult> ContentQueryResults { get; set; }

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