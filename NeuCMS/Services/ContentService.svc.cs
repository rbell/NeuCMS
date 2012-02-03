using System.Linq;
using NeuCMS.Core.Repositories;

namespace NeuCMS.Services
{
    public class ContentService : IContentService
    {
        public ContentQueryResults QueryContent(ContentQueryCriteria criteria)
        {
		
        	var repository = new RepositoryFactory().ContentRepository();

            var atoms = repository.Atoms.Where(criteria.WhereExpression);

        	var results = new ContentQueryResults();
        	foreach (var atom in atoms)
        	{
        		results.Add(new ContentQueryResult() {ContentKey = atom.Name, Content = atom.Content});
        	}

            return results;
        }

    }
}
