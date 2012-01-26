using System.Collections.Generic;

namespace NeuCMS.Core.Entities
{
    public class AtomDefinition : IEntity
    {
        public string Id { get; set; }

        /// <summary>
        /// Name of the Atom that we are defining.  For instance "LoginLabel".
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// NameSpace that scopes the uniqueness of the Name.  For instance the name of the application.
        /// The value of Name can only be defined once for a given NameSpace
        /// </summary>
        public string NameSpace { get; set; }

        private List<ContentMetadataDefinition> metadataDefinition { get; set; }
    }
}