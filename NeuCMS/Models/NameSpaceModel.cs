using System.ComponentModel;
using NeuCMS.Core.Entities;

namespace NeuCMS.Models
{
    public class NameSpaceGridModel
    {
        public NameSpaceGridModel(NameSpace ns)
        {
            Id = ns.Id;
            NameSpaceName = ns.NameSpaceName;
            Description = ns.Description;
        }

        public int Id { get; set; }
        [DisplayName("Name Space")]
        public string NameSpaceName { get; set; }
        public string Description { get; set; }
    }
}