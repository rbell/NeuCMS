namespace NeuCMS.Core.Entities
{
    public class ContentMetadataValue
    {
        public int ContentMetadataValueId { get; set; }
        public ContentMetadataDefinition MetaDataDefinition { get; set; }
        public string Value { get; set; }
    }
}