using System.Collections.Generic;

namespace NeuCMS.Core.Entities
{
    public abstract class Content : IEntity
    {
        public string Id { get; set; }
        public List<ContentMetadata> ContentMetadata { get; set; }
    }
}