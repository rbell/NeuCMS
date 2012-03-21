namespace NeuCMS.Core.Entities
{
    public class View
    {
        public int ViewId { get; set; }
        public int NameSpaceId { get; set; }
        public NameSpace NameSpace { get; set; }
        public string ViewName { get; set; }
    }
}