using System.Data.Services.Common;

namespace NeuCMS.Core.Entities
{
    [DataServiceKey("Id")]
    public class ContentMetadataValue
    {
        public int Id { get; set; }
        public virtual ContentMetadataDefinition MetaDataDefinition { get; set; }
        public string Value { get; set; }
    }
}