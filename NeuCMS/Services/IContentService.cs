using System.ServiceModel;

namespace NeuCMS.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IContentService" in both code and config file together.
    [ServiceContract]
    public interface IContentService
    {
        [OperationContract]
        ContentQueryResults QueryContent(ContentQueryCriteria criteria);
    }
}
