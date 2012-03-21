namespace NeuCMS.Core.Entities
{
    public class DimensionDefinition
    {
        public string DimensionDefinitionId { get; set; }
        public string NamespaceId { get; set; }
        public NameSpace NameSpace { get; set; }
        public string DimensionName { get; set; }
    }
}