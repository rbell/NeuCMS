using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using NeuCMS.Core.Repositories;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;

namespace NeuCMS.Repositories.EmbeddedRavenDB
{
	public class RepositoryContext : IRepositoryContext
	{
		private EmbeddableDocumentStore _documentStore;
		private IDocumentSession _session;
		private Dictionary<Type, RavenObjectSet> _objectSets = new Dictionary<Type, RavenObjectSet>();

		public RepositoryContext()
		{
			_documentStore = new EmbeddableDocumentStore() { ConnectionStringName = "ContentRepository" };
			_documentStore.Initialize();
			_session = _documentStore.OpenSession();
		}

		public int Save()
		{
			_session.SaveChanges();
			// TODO: return values saved by analysing ObjectSets
			return 0;
		}

		public void Dispose()
		{
			_session.SaveChanges();
			_session.Dispose();
		}

		public IObjectSet<T> ObjectSet<T>() where T : class 
		{
			if (!_objectSets.ContainsKey(typeof(T)))
			{
				_objectSets.Add(typeof(T),new RavenObjectSet<T>(_session));
			}
			return _objectSets[typeof (T)] as RavenObjectSet<T>;
		}
	}
}