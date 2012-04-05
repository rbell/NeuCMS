using System.Data.Services.Common;

namespace NeuCMS.Core.Entities
{
    [DataServiceKey("Id")]
    public class DimensionValue
    {
        public int Id { get; set; }
        public virtual DimensionDefinition DimensionDefinition { get; set; }
        public string Value { get; set; }
    }
}