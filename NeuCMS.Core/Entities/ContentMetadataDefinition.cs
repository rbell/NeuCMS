using System.Data.Services.Common;

namespace NeuCMS.Core.Entities
{
    [DataServiceKey("Id")]
    public class ContentMetadataDefinition
    {
        public int Id { get; set; }

        public int ContentDefinitionId { get; set; }
        public virtual ContentDefinition ContentDefinition { get; set; }

        public string MetadataName { get; set; }

        //TODO: Other properties that define rules for Metadata values (i.e. Regex)
    }
}