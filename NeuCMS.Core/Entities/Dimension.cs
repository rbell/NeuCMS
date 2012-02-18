namespace NeuCMS.Core.Entities
{
    public class Dimension : IEntity
    {
        public string Id { get; set; }
        public string DimensionDefinitionId { get; set; }
        public string NamespaceId { get; set; }
        public string NameSpace { get; set; }
        public string DimensionName { get; set; }
    }
}