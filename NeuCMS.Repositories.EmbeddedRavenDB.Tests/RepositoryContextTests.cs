using System.Linq;
using NUnit.Framework;

namespace NeuCMS.Repositories.EmbeddedRavenDB.Tests
{
	[TestFixture]
	public class RepositoryContextTests
	{
		[Test]
		public void AddClassToSetAndSave_Saves()
		{
			var contxt = new RepositoryContext();
			contxt.ObjectSet<TestClass>().AddObject(new TestClass() {FirstName = "Donald", LastName = "Duck"});
			contxt.Save();

			var duck = (from tc in contxt.ObjectSet<TestClass>() where tc.FirstName == "Donald" select tc).FirstOrDefault();
			Assert.That(duck, Is.Not.Null);
		}
	}
}