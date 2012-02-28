using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using NeuCMS.Core.Entities;
using NeuCMS.Core.Repositories;

namespace NeuCMS.Repositories.EmbeddedRavenDB
{
	public class Repository : IContentRepository
	{
		private IRepositoryContext _context;
		public Repository(IRepositoryContext context)
		{
			_context = context;
		}

		public void Setup()
		{
			throw new NotImplementedException();
		}

		public bool IsSetup
		{
			get { throw new NotImplementedException(); }
		}

		public void Init()
		{
			throw new NotImplementedException();
		}

		public void Dismantle()
		{
			throw new NotImplementedException();
		}

	    public IObjectSet<ContentElement> Atoms
	    {
            get { return _context.ObjectSet<ContentElement>(); }
	    }

	    public IObjectSet<ContentNameSpace> ContentNameSpaces
	    {
            get { return _context.ObjectSet<ContentNameSpace>(); }
        }

	    public IObjectSet<Page> Pages
	    {
            get { return _context.ObjectSet<Page>(); }
        }

        public IObjectSet<ContentMetadataDefinition> ContentMetadataDefinitions
	    {
            get { return _context.ObjectSet<ContentMetadataDefinition>(); }
        }

	    public IObjectSet<DimensionDefinition> DimentionDefinitions
	    {
            get { return _context.ObjectSet<DimensionDefinition>(); }
        }

	    public IObjectSet<ContentElementDefinition> AtomDefinitions
	    {
            get { return _context.ObjectSet<ContentElementDefinition>(); }
        }

	    public void Commit()
		{
			_context.Save();
		}
	}
}