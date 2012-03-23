using System.Linq;
using NeuCMS.Core.Entities;
using NeuCMS.Core.Repositories;

namespace NeuCMS.Services
{
    public class ContentService : IContentService
    {
        public ContentQueryResults QueryContent(ContentQueryCriteria criteria)
        {
		
        	var repository = new RepositoryFactory().ContentRepository();

            var elements = repository.Contents.OfType<ElementContent>().Where(criteria.WhereExpression);

        	var results = new ContentQueryResults();
        	foreach (var element in elements)
        	{
        		results.Add(new ContentQueryResult() {ContentKey = element.ContentElementDefinition.Name, Content = element.Content});
        	}

            return results;
        }

    }
}
