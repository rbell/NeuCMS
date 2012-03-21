namespace NeuCMS.Core.Entities
{
    public class ContentMetadataDefinition
    {
        public int ContentMetadataDefinitionId { get; set; }

        public int ContentDefinitionId { get; set; }
        public ContentDefinition ContentDefinition { get; set; }

        public string MetadataName { get; set; }

        //TODO: Other properties that define rules for Metadata values (i.e. Regex)
    }
}