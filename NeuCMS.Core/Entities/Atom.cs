using System.Collections.Generic;

namespace NeuCMS.Core.Entities
{
    public class Atom : Content
    {
        /// <summary>
        /// Name of this Atom
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// NameSpace for the Atom.  For instance the name of the application this content is used in.
        /// </summary>
        public string NameSpace { get; set; }

        /// <summary>
        /// The Content of the Atom
        /// </summary>
        public string Content { get; set; }

        private List<ContentMetadata> MetaData { get; set; }

    }
}