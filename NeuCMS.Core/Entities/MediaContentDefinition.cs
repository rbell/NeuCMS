using System.Collections.Generic;

namespace NeuCMS.Core.Entities
{
    public class MediaContentDefinition : ContentDefinition
    {
        public bool AvailableOnAllViews { get; set; }
        public ICollection<View> Views { get; set; }

        public DigitalAssetDefinition DigitalAssetDefinition
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
