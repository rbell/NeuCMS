using System.Collections.Generic;
using System.Data.Services.Common;

namespace NeuCMS.Core.Entities
{
    public class ElementContent : Content
    {
        /// <summary>
        /// The Content of the Atom
        /// </summary>
        public string Content { get; set; }

    }
}