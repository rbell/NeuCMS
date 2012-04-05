using System.Collections.Generic;
using System.Data.Services.Common;

namespace NeuCMS.Core.Entities
{
    [DataServiceKey("Id")]
    public class View
    {
        public int Id { get; set; }
        public int NameSpaceId { get; set; }
        public NameSpace NameSpace { get; set; }
        public string ViewName { get; set; }
        public virtual List<ContentDefinition> ContentDefinitions { get; set; }
    }
}