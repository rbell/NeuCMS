namespace NeuCMS.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ContentService" in code, svc and config file together.
    public class ContentService : IContentService
    {
        public ContentQueryResults QueryContent(ContentQueryCriteria criteria)
        {
		
        	var repository = new RepositoryFactory().ContentRepository();

        	var atoms =
        		(from atom in repository.Atoms
				 where atom.NameSpace == "NeuCMS.Samples"
        		 select atom);

        	var results = new ContentQueryResults();
        	foreach (var atom in atoms)
        	{
        		results.Add(new ContentQueryResult() {ContentKey = atom.Name, Content = atom.Content});
        	}

            return results;
        }

    }
}
