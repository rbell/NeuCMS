using System.Collections.Generic;
using System.Data.Services.Common;

namespace NeuCMS.Core.Entities
{
    [DataServiceKey("Id")]
    public abstract class Content
    {
        public int Id { get; set; }

        public virtual ContentDefinition ContentElementDefinition { get; set; }

        public virtual List<DimensionValue> Dimensions { get; set; }

        public virtual List<ContentMetadataValue> ContentMetadata { get; set; }
    }
}