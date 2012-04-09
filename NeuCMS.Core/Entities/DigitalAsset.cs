using System.Data.Services.Common;

namespace NeuCMS.Core.Entities
{
    [DataServiceKey("Id")]
    public class DigitalAsset
    {
        public int Id { get; set; }
        public int ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}
