using System;
using System.Collections.Generic;
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


        void Commit();


    }
}