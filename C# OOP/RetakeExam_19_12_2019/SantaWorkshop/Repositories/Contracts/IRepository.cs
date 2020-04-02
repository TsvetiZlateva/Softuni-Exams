﻿namespace SantaWorkshop.Repositories.Contracts
{
    using SantaWorkshop.Models.Dwarfs;
    using SantaWorkshop.Models.Dwarfs.Contracts;
    using System;
    using System.Collections.Generic;

    public interface IRepository<T> 
    {
        IReadOnlyCollection<T> Models { get; }

        void Add(T model);

        bool Remove(T model);

        T FindByName(string name);
    }
}
