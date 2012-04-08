using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using NeuCMS.Core.Entities;

namespace NeuCMS.Platforms.MVC3
{
    public class ContentRepository : DataServiceContext
    {
        public ContentRepository(Uri serviceRoot) : base(serviceRoot)
        {
        }

        public IQueryable<ContentQueryResult> ContentQueryResults
        {
            get { return CreateQuery<ContentQueryResult>("ContentQueryResults"); }
        }

        public IEnumerable<ContentQueryResult> GetViewContents(string nameSpace, string viewName, string dimensionValues)
        {
            var getGetViewContentsUri =
                new Uri(this.BaseUri,
                        string.Format("GetViewContents?nameSpace='{0}'&viewName='{1}'&dimensionValues='{2}'", nameSpace,
                                      viewName, dimensionValues));

            var contents = Execute<ContentQueryResult>(getGetViewContentsUri);

            return contents;
        }
    }
}