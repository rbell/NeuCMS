using System.Data.Services.Common;

namespace NeuCMS.Core.Entities
{
    [DataServiceKey("Id")]
    public class DimensionDefinition
    {
        public int Id { get; set; }
        public string NamespaceId { get; set; }
        public virtual NameSpace NameSpace { get; set; }
        public string DimensionName { get; set; }
    }
}