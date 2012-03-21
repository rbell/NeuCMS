using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using NeuCMS.Core.Entities;

namespace NeuCMS.Core.Repositories
{
    public interface IContentRepository
    {
        IDbSet<Content> Contents { get; }
        IDbSet<DigitalAsset> DigitalAssets { get; }
        IDbSet<ContentDefinition> ContentDefinitions { get; }
        IDbSet<ContentMetadataValue> ContentMetadataValues { get; }
        IDbSet<ContentMetadataDefinition> ContentMetadataDefinitions { get; }
        IDbSet<DimensionValue> DimensionValues { get; }
        IDbSet<DimensionDefinition> DimensionDefinitions { get; }
        IDbSet<View> Views { get; }
        IDbSet<NameSpace> NameSpaces { get; }
        void Commit();

    }
}