using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using Raven.Client;

namespace NeuCMS.Repositories.EmbeddedRavenDB
{
	public abstract class RavenObjectSet
	{
		
	}

	public class RavenObjectSet<T> : RavenObjectSet, IObjectSet<T> where T: class
	{
		private IDocumentSession _session;
		private IQueryable<T> _query;

		public RavenObjectSet(IDocumentSession session)
		{
			_session = session;
			_query = _session.Query<T>();
		}

		public IEnumerator<T> GetEnumerator()
		{
			return _query.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _query.GetEnumerator();
		}

		public Expression Expression
		{
			get { return _query.Expression; }
		}

		public Type ElementType
		{
			get { return _query.ElementType; }
		}

		public IQueryProvider Provider
		{
			get { return _query.Provider; }
		}

		public void AddObject(T entity)
		{
			_session.Store(entity);
		}

		public void Attach(T entity)
		{
			_session.Store(entity);
		}

		public void DeleteObject(T entity)
		{
			_session.Delete(entity);
		}

		public void Detach(T entity)
		{
			_session.Advanced.Evict(entity);
		}
	}
}