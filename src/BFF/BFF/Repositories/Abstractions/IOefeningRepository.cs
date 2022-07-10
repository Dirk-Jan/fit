using System;
using System.Collections.Generic;
using BFF.Models;

namespace BFF.Repositories.Abstractions
{
    public interface IOefeningRepository
    {
        IEnumerable<Oefening> GetAll();
        IEnumerable<Oefening> GetAllWithSomePrestaties();
        Oefening GetById(Guid id);
        void Add(Oefening oefening);
        void Edit(Oefening oefening);
    }
}