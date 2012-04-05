using System.Data.Services.Common;

namespace NeuCMS.Core.Entities
{
    public class MediaContent : NeuCMS.Core.Entities.Content
    {
        public virtual DigitalAsset DigitalAsset { get; set; }
    }
}
