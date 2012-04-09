using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NUnit.Framework;
using NeuCMS.Core.Entities;
using NeuCMS.Repositories.EntityFramework;

namespace NeuCMS.Repositories.EntityFramework.Tests
{
    [TestFixture]
    public class RepositoryTests
    {
        [Test]
        public void GetViewContent()
        {
            var dimensions = new List<QueryKeyValue>()
                                 {
                                     new QueryKeyValue("Language", "English")
                                 };

            using (var db = new ContentRepository())
            {
                var dbcontents = (from content in db.Contents.OfType<ElementContent>()
                                where content.ContentElementDefinition.NameSpace.NameSpaceName == "NeuCMS.Samples" &&
                                      (from v in content.ContentElementDefinition.Views select v.ViewName).Contains(
                                          "Home")
                                select content).ToList();

                var dbMediaContents = (from content in db.Contents.OfType<MediaContent>()
                                       where
                                           content.ContentElementDefinition.NameSpace.NameSpaceName == "NeuCMS.Samples" &&
                                           (from v in content.ContentElementDefinition.Views select v.ViewName).Contains
                                               ("Home")
                                       select content).ToList();

                 var contents = dbcontents.Where(c => c.MatchesDimensions(dimensions)).Select(
                        c => new ContentQueryResult()
                                 {
                                     Id = c.Id,
                                     Content = c.Content,
                                     ContentKey = c.ContentElementDefinition.Name
                                 })
                                 .Union(
                                    dbMediaContents.Where(m => m.MatchesDimensions(dimensions)).Select(
                                    m => new ContentQueryResult()
                                             {
                                                 Id = m.Id,
                                                 Content = "http://something",
                                                 ContentKey = m.ContentElementDefinition.Name
                                             })
                                 );

                Assert.That(contents.Any(), Is.True);
                var lst = contents.ToList();
                Assert.That(contents, Is.Not.Empty);
            }

        }
    }
}