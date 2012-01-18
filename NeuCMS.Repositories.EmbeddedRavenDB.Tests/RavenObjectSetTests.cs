using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;
using Raven.Client.Linq;

namespace NeuCMS.Repositories.EmbeddedRavenDB.Tests
{
	[TestFixture]
	public class RavenObjectSetTests
	{
		private DocumentStore _documentStore;

		[SetUp]
		public void Setup()
		{
			_documentStore = new EmbeddableDocumentStore() { RunInMemory = true};
			_documentStore.Initialize();
		}

		[TearDown]
		public void TearDown()
		{
			_documentStore.Dispose();
		}

		[Test]
		public void SaveNewObject_SavesObject()
		{
			using (var session = _documentStore.OpenSession())
			{
				var set = new RavenObjectSet<TestClass>(session);
				set.AddObject(new TestClass() { FirstName = "Donald", LastName = "Duck" });
				session.SaveChanges();
			}

			using (var session = _documentStore.OpenSession())
			{
				TestClass duck = (from tc in session.Query<TestClass>() where tc.FirstName == "Donald" select tc).FirstOrDefault();
				Assert.That(duck, Is.Not.Null);
			}

		}
	}
}
