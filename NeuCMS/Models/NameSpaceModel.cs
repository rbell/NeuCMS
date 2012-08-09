using System.ComponentModel;
using Lib.Web.Mvc.JQuery.JqGrid.DataAnnotations;
using NeuCMS.Core.Entities;

namespace NeuCMS.Models
{
    public class NameSpaceGridModel
    {
        public NameSpaceGridModel()
        {
        }

        public NameSpaceGridModel(NameSpace ns)
        {
            Id = ns.Id;
            NameSpaceName = ns.NameSpaceName;
            Description = ns.Description;
        }

        [JqGridColumnLayout(Width = 40)]
        public int Id { get; set; }

        [DisplayName("Name Space")]
        [JqGridColumnLayout(Width = 200)]
        public string NameSpaceName { get; set; }

        [JqGridColumnLayout(Width = 300)]
        public string Description { get; set; }
    }
}