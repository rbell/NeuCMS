using System.Collections.Generic;

namespace NeuCMS.Core.Entities
{
    public class ElementContentDefinition : ContentDefinition
    {
        public bool AvailableOnAllViews { get; set; }
        public ICollection<View> Views { get; set; }
    }
}