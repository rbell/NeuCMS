using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using NeuCMS.Core.Entities;
using NeuCMS.Repositories.EntityFramework;

namespace NeuCMS.Services
{
    public class ContentRepositoryService : DataService<ContentRepository>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:
            // config.SetEntitySetAccessRule("MyEntityset", EntitySetRights.AllRead);
            // config.SetServiceOperationAccessRule("MyServiceOperation", ServiceOperationRights.All);
            config.SetServiceOperationAccessRule("GetViewContents", ServiceOperationRights.AllRead);
            config.SetEntitySetAccessRule("Contents", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("DigitalAssets", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("ContentDefinitions", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("ContentMetadataValues", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("ContentMetadataDefinitions", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("DimensionValues", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("DimensionDefinitions", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("Views", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("NameSpaces", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("ContentQueryResults", EntitySetRights.AllRead);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
        }

        [WebGet]
        public IQueryable<ContentQueryResult> GetViewContents(string nameSpace, string viewName, string dimensionValues )
        {
            var dimensions = dimensionValues.ParseQueryKeyValues();

            var dbcontents = (from content in this.CurrentDataSource.Contents.OfType<ElementContent>()
                              where content.ContentElementDefinition.NameSpace.NameSpaceName == "NeuCMS.Samples" &&
                                    (from v in content.ContentElementDefinition.Views select v.ViewName).Contains(
                                        "Home")
                              select content).ToList();

            var contents = dbcontents.Where(c => c.MatchesDimensions(dimensions)).Select(
                   c => new ContentQueryResult()
                   {
                       Id = c.Id,
                       Content = c.Content,
                       ContentKey = c.ContentElementDefinition.Name
                   }).AsQueryable();

            //var viewContents = from content in this.CurrentDataSource.Contents.OfType<ElementContent>()
            //                   where content.ContentElementDefinition.NameSpace.NameSpaceName == nameSpace &&
            //             (from v in content.ContentElementDefinition.Views select v.ViewName).Contains(viewName)
            //                   select new ContentQueryResult()
            //                   {
            //                       Id = content.Id,
            //                       Content = content.Content,
            //                       ContentKey = content.ContentElementDefinition.Name,
            //                   };
            return contents;
        }

    }
}
