using System.Collections.Generic;
using System.Data.Services.Common;

namespace NeuCMS.Core.Entities
{
    [DataServiceKey("Id")]
    public class NameSpace
    {
        public int Id { get; set; }
        public string NameSpaceName { get; set; }
        public string Description { get; set; }
        public virtual List<DimensionDefinition> DiminsionDefinitions { get; set; }
        public virtual List<View> Views { get; set; }
    }
}