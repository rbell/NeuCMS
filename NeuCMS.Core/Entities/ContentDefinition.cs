using System.Collections.Generic;

namespace NeuCMS.Core.Entities
{
    public abstract class ContentDefinition
    {
        public int ContentDefinitionId { get; set; }

        /// <summary>
        /// Name of the Atom that we are defining.  For instance "LoginLabel".
        /// </summary>
        public string Name { get; set; }

        public ICollection<NeuCMS.Core.Entities.ContentMetadataDefinition> MetaDataDefinition { get; set; }

    }
}