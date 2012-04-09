using System.Collections.Generic;
using System.Drawing;
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

            var contentDef1 = new ContentDefinition()
            {
                Id = 1,
                Name = "Message",
                NameSpace = nameSpace,
                AvailableOnAllViews = false
            };

            var contentDef2 = new ContentDefinition()
            {
                Id = 2,
                Name = "Image",
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
                                                            contentDef1, 
                                                            contentDef2
                                                        }
            };

            var dimDef = new DimensionDefinition() { Id = 1, DimensionName = "Language", NameSpace = nameSpace };

            var elementContent = new ElementContent()
            {
                Id = 1,
                Content = "Hello World!",
                ContentElementDefinition = view.ContentDefinitions[0],
                Dimensions = new List<DimensionValue>()
                                                          {
                                                              new DimensionValue()
                                                                  {
                                                                      Id = 1,
                                                                      DimensionDefinition = dimDef,
                                                                      Value = "English"
                                                                  }
                                                          }
            };

            var converter = new ImageConverter();
            var imgBytes = (byte[])converter.ConvertTo(TestData.Test, typeof(byte[]));

            var mediaContent = new MediaContent()
            {
                Id = 2,
                ContentElementDefinition = view.ContentDefinitions[1],
                Dimensions = new List<DimensionValue>()
                                                        {
                                                            new DimensionValue()
                                                                {
                                                                    Id = 1,
                                                                    DimensionDefinition = dimDef,
                                                                    Value = "English"
                                                                }
                                                        },
                DigitalAsset = new DigitalAsset()
                {
                    Id = 1,
                    ContentType = "image/jpeg",
                    Data = imgBytes
                }
            };

            context.Views.AddOrUpdate(v => v.Id, view);
            context.ContentDefinitions.AddOrUpdate(c => c.Name, contentDef1);
            context.DimensionDefinitions.AddOrUpdate(d => d.DimensionName, dimDef);
            context.Contents.AddOrUpdate(c => c.Id, elementContent);
            context.Contents.AddOrUpdate(c => c.Id, mediaContent);
        }
    }
}
