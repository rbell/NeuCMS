namespace NeuCMS.Core.Entities
{
    public class Page : IEntity
    {
        public string Id { get; set; }
        public string NameSpaceId { get; set; }
        public string NameSpace { get; set; }
        public string PageName { get; set; }
    }
}