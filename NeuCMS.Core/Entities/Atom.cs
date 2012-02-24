using System.Collections.Generic;

namespace NeuCMS.Core.Entities
{
    public class Atom : Content
    {
        public string AtomDefinitionId { get; set; }

        /// <summary>
        /// NameSpace for the Atom.  For instance the name of the application this content is used in.
        /// </summary>
        public string NameSpace { get; set; }

        public bool UseOnAllPages { get; set; }

        public List<string> Pages { get; set; }

        public List<Dimension> Dimensions { get; set; }

        public List<ContentMetadata> MetaData { get; set; }

        /// <summary>
        /// Name of this Atom
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Content of the Atom
        /// </summary>
        public string Content { get; set; }

    }
}