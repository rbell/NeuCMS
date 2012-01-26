using System.Linq;
using NUnit.Framework;
using NeuCMS.Core.Entities;
using NeuCMS.Core.Repositories;

namespace NeuCMS.Repositories.EmbeddedRavenDB.Tests
{
	[TestFixture]
	public class RepositoryTests
	{
		private IContentRepository _repository;

		[SetUp]
		public void Setup()
		{
			_repository = new RepositoryFactory().UseEmbeddedRavenDB().ContentRepository();
		}

		[Test]
		public void AddAtom_SavesAtom()
		{
			_repository.Atoms.AddObject(new Atom() { Content = "This is a test", Name = "TestContent", NameSpace = "TestNamespace" });
			_repository.Commit();

			var testAtom =
				(from atom in _repository.Atoms
				 where atom.Name == "TestContent" && atom.NameSpace == "TestNamespace"
				 select atom).FirstOrDefault();

			Assert.That(testAtom, Is.Not.Null);
			Assert.That(testAtom.Content, Is.EqualTo("This is a test"));

		}

		[Test]
		[Explicit]
		public void AddTestData()
		{
			var nameSpace = "NeuCMS.Samples";
			_repository.Atoms.AddObject(new Atom() { Content = "This is fun!", Name = "Message", NameSpace = nameSpace });
			_repository.Commit();

			var atoms =
				(from atom in _repository.Atoms
				 where atom.NameSpace == nameSpace
				 select atom).ToList();

			Assert.That(atoms, Is.Not.Null.And.Not.Empty);

		}

		[Test]
		[Explicit]
		public void VerifyTestData()
		{
			var atoms =
				(from atom in _repository.Atoms
				 where atom.NameSpace == "NeuCMS.Samples"
				 select atom).ToList();

			Assert.That(atoms, Is.Not.Null.And.Not.Empty);
		}
	}
}