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
                db.SaveChanges();
            }
        }

    }
}