using System;
using System.Collections.Generic;
using NeuCMS.Core.Entities;

namespace NeuCMS.Core.Repositories
{
    public interface IContentRepository
    {
        void Setup();

        bool IsSetup { get; }

        void Init();

        void Dismantle();

        T SingleOrDefault<T>(Func<T, bool> predicate) where T : IEntity;

        IEnumerable<ThreadStaticAttribute> All<T>() where T : IEntity;

        void Add<T>(T item) where T : IEntity;

        void Update<T>(T item) where T : IEntity;

        void Delete<T>(T item) where T : IEntity;

        void Commit();


    }
}