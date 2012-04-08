using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NeuCMS.Core.Entities;
using NeuCMS.Repositories.EntityFramework_43;
using NeuCMS.Services;

namespace NeuCMS.Tests
{
    [TestFixture]
    public class ContentRepositoryDataModelTests
    {
        [Test]
        public void temp()
        {
            using (var db = new ContentRepository())
            {
                var contents = from content in db.Contents.OfType<ElementContent>()
                               where content.ContentElementDefinition.NameSpace.NameSpaceName == "NeuCMS.Samples" &&
                               (from v in content.ContentElementDefinition.Views select v.ViewName).Contains("Home")
                               select new ContentQueryResult()
                               {
                                   Id = content.Id,
                                   Content = content.Content,
                                   ContentKey = content.ContentElementDefinition.Name,
                               };

                Assert.That(contents.Any(), Is.True);
                var lst = contents.ToList();
                Assert.That(contents, Is.Not.Empty);
            }
        }
    }
}
