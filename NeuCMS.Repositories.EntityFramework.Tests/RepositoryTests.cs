using System.Collections.Generic;
using System.Data.Entity;
using NUnit.Framework;
using NeuCMS.Core.Entities;
using NeuCMS.Repositories.EntityFramework_43;

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
                                 Description = "Test Description",
                                 NameSpaceName = "Test Name"
                             };
                db.NameSpaces.Add(ns);

                var view = new View()
                               {
                                   NameSpace = ns,
                                   ViewName = "TestView",
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

                var content = new ElementContent()
                                  {
                                      Content = "Hello World!",
                                      ContentElementDefinition = view.ContentDefinitions[0]
                                  };
                db.Contents.Add(content);

                db.SaveChanges();
            }
        }

    }
}