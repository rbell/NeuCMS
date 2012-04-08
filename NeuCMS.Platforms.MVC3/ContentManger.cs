using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using NeuCMS.Core.Entities;

namespace NeuCMS.Platforms.MVC3
{
    public static class ContentManger
    {
        public static void InitContent(dynamic viewBag, string nameSpace, string page, Dictionary<string, string> dimensions)
        {
            var repository = new ContentRepository(
                new Uri(System.Configuration.ConfigurationManager.AppSettings["NeuCMSServiceURL"])
                );

            var content = repository.GetViewContents(nameSpace,page, dimensions.ToQueryString()).ToList(); 
       
            dynamic neuCMSContent = new NeuCMSContent(content);
            viewBag.NeuContent = neuCMSContent;
        }
    }

    public class NeuCMSContent : DynamicObject
    {
        private List<ContentQueryResult> _results;

        public NeuCMSContent(List<ContentQueryResult> content)
        {
            _results = content;
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
