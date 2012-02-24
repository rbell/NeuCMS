using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using NeuCMS.Platforms.MVC3.ContentService;

namespace NeuCMS.Platforms.MVC3
{
    public static class ContentManger
    {
        public static void InitContent(dynamic viewBag, string nameSpace, string page, Dictionary<string, string> dimensions)
        {
            var client = ServiceClientFactory.CreateClient();
            var content = client.QueryContent(new ContentQueryCriteria()
                                                  {
                                                      NameSpace = nameSpace,
                                                      Pages = new List<string>() {page},
                                                      Dimensions = (from KeyValuePair<string, string> d in dimensions
                                                                    select
                                                                        new DimensionCriteria()
                                                                            {
                                                                                DimensionName = d.Key,
                                                                                DimensionValue = d.Value
                                                                            }).ToList()
                                                  });
            dynamic neuCMSContent = new NeuCMSContent(content);
            viewBag.NeuContent = neuCMSContent;
        }
    }

    public class NeuCMSContent : DynamicObject
    {
        private List<ContentQueryResult> _results;

        public NeuCMSContent(ContentQueryResults content)
        {
            _results = content.Results;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = (from queryResult in _results
                      where queryResult.ContentKey == binder.Name
                      select queryResult.Content)
                     .FirstOrDefault();
            return result != null;
        }
    }
}
