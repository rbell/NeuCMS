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
        public void temp()
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ContentRepository>());
            using (var db = new ContentRepository())
            {
                var ns = new NameSpace()
                             {
                                 Description = "Sample NeuCMS Content Data",
                                 NameSpaceName = "NeuCMS.Samples"
                             };
                db.NameSpaces.Add(ns);

                var view = new View()
                               {
                                   NameSpace = ns,
                                   ViewName = "Home",
                                   ContentDefinitions = new List<ContentDefinition>()
                                                            {
                                                                new ContentDefinition()
                                                                    {
                                                                        Name = "Message",
                                                                        NameSpace = ns,
                                                                        AvailableOnAllViews = false                                                                    }
                                                            }
                               };
                db.Views.Add(view);

                var dimDef = new DimensionDefinition() {DimensionName = "Language", NameSpace = ns};
                db.DimensionDefinitions.Add(dimDef);

                var content = new ElementContent()
                                  {
                                      Content = "Hello World!",
                                      ContentElementDefinition = view.ContentDefinitions[0],
                                      Dimensions = new List<DimensionValue>()
                                                       {
                                                           new DimensionValue()
                                                               {DimensionDefinition = dimDef, Value = "English"}
                                                       }
                                  };
                db.Contents.Add(content);

                db.SaveChanges();
            }
        }

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