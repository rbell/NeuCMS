using System.Collections.Generic;

namespace NeuCMS.Core.Entities
{
    public class NameSpace
    {
        public int NameSpaceId { get; set; }
        public string NamespaceDefinitionId { get; set; }
        public string NameSpaceName { get; set; }
        public string Description { get; set; }
        public ICollection<DimensionDefinition> DiminsionDefinitions { get; set; }
        public ICollection<View> Views { get; set; }
    }
}