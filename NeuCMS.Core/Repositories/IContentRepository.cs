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

        IObjectSet<Atom> Atoms { get; } 

        void Commit();

    }
}