namespace NeuCMS.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ContentService" in code, svc and config file together.
    public class ContentService : IContentService
    {
        public ContentQueryResults QueryContent(ContentQueryCriteria criteria)
        {
            return new ContentQueryResults()
                       {
                           new ContentQueryResult() {ContentKey = "Message", Content = "Welcome to ASP.NET MVC!!!!"},
                           new ContentQueryResult() {ContentKey = "Image", Content = "http://localhost:17255/Assets/Asset?id=Test"}
                       };
        }

    }
}
