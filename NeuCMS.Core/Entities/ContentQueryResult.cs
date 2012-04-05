using System.Collections.Generic;
using System.Data.Services.Common;

namespace NeuCMS.Core.Entities
{
    [DataServiceKey("Id")]
    public class ContentQueryResult
    {
        public int Id { get; set; }

        public string NameSpace { get; set; }

        public string ContentKey { get; set; }

        public string Content { get; set; }

        public ICollection<DimensionValue> Dimensions { get; set; }

        public ICollection<ContentMetadataValue> ContentMetadata { get; set; }

        public ICollection<View> Views { get; set; }

        public bool AvailableOnAllViews { get; set; }

    }
}