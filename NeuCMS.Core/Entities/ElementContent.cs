using System.Collections.Generic;

namespace NeuCMS.Core.Entities
{
    public class ElementContent : Content
    {

        public string ContentElementDefinitionId { get; set; }
        public ElementContentDefinition ContentElementDefinition { get; set; }

        /// <summary>
        /// The Content of the Atom
        /// </summary>
        public string Content { get; set; }

    }
}