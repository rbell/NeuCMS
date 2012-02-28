using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using NeuCMS.Core.Entities;

namespace NeuCMS.Core.Repositories
{
    public interface IContentRepository
    {
        void Setup();

        bool IsSetup { get; }

        void Init();

        void Dismantle();

        IObjectSet<ContentElement> Atoms { get; }

        IObjectSet<ContentNameSpace> ContentNameSpaces { get; }
        IObjectSet<Page> Pages { get; } 
        IObjectSet<DimensionDefinition> DimentionDefinitions { get; }
        IObjectSet<ContentMetadataDefinition> ContentMetadataDefinitions { get; }
        IObjectSet<ContentElementDefinition> AtomDefinitions { get; } 


        void Commit();

    }
}