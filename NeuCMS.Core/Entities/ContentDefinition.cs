using System.Collections.Generic;
using System.Data.Services.Common;

namespace NeuCMS.Core.Entities
{
    [DataServiceKey("Id")]
    public class ContentDefinition
    {
        public int Id { get; set; }

        /// <summary>
        /// Name of the Atom that we are defining.  For instance "LoginLabel".
        /// </summary>
        public string Name { get; set; }

        public virtual NameSpace NameSpace { get; set; }

        public bool AvailableOnAllViews { get; set; }
        public virtual List<View> Views { get; set; }
        public virtual List<NeuCMS.Core.Entities.ContentMetadataDefinition> MetaDataDefinition { get; set; }
    }
}