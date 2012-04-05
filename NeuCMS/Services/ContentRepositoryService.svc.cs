using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using NeuCMS.Core.Entities;
using NeuCMS.Repositories.EntityFramework_43;

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
            config.SetEntitySetAccessRule("ViewContents", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("Contents", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("DigitalAssets", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("ContentDefinitions", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("ContentMetadataValues", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("ContentMetadataDefinitions", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("DimensionValues", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("DimensionDefinitions", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("Views", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("NameSpaces", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("ViewContents", EntitySetRights.AllRead);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
        }
    }
}
