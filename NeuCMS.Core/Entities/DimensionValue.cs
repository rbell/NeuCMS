namespace NeuCMS.Core.Entities
{
    public class DimensionValue
    {
        public int DimensionValueId { get; set; }
        public DimensionDefinition DimensionDefinition { get; set; }
        public string Value { get; set; }
    }
}