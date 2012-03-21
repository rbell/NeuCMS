using System.Collections.Generic;

namespace NeuCMS.Core.Entities
{
    public abstract class Content
    {
        public int ContentId { get; set; }

        public ICollection<DimensionValue> Dimensions { get; set; }

        public ICollection<ContentMetadataValue> ContentMetadata { get; set; }
    }
}