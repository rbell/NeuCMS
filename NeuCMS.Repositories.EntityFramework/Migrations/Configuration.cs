using System.Collections.Generic;
using NeuCMS.Core.Entities;

namespace NeuCMS.Repositories.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NeuCMS.Repositories.EntityFramework.ContentRepository>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NeuCMS.Repositories.EntityFramework.ContentRepository context)
        {
            var nameSpace = new NameSpace()
                                {
                                    Id = 1,
                                    Description = "Sample NeuCMS Content Data",
                                    NameSpaceName = "NeuCMS.Samples"
                                };


            context.NameSpaces.AddOrUpdate(
                n => n.Id,
                nameSpace);

            var contentDef = new ContentDefinition()
                                 {
                                     Id = 1,
                                     Name = "Message",
                                     NameSpace = nameSpace,
                                     AvailableOnAllViews = false
                                 };

            var view = new View()
                           {
                               Id = 1,
                               NameSpace = nameSpace,
                               ViewName = "Home",
                               ContentDefinitions = new List<ContentDefinition>()
                                                        {
                                                            contentDef
                                                        }
                           };

            var dimDef = new DimensionDefinition() {Id = 1, DimensionName = "Language", NameSpace = nameSpace };

            var elementContent = new ElementContent()
            {
                Id = 1,
                Content = "Hello World!",
                ContentElementDefinition = view.ContentDefinitions[0],
                Dimensions = new List<DimensionValue>()
                                                       {
                                                           new DimensionValue()
                                                               {Id = 1, DimensionDefinition = dimDef, Value = "English"}
                                                       }
            };

            context.Views.AddOrUpdate(v => v.Id, view);
            context.ContentDefinitions.AddOrUpdate(c => c.Name, contentDef);
            context.DimensionDefinitions.AddOrUpdate(d => d.DimensionName, dimDef);
            context.Contents.AddOrUpdate(c => c.Id, elementContent);
            
        }
    }
}
