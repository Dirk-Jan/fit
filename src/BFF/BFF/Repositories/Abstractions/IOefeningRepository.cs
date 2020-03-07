using System.Collections;
using System.Collections.Generic;
using BFF.Models;

namespace BFF.Repositories.Abstractions
{
    public interface IOefeningRepository
    {
        IEnumerable<Oefening> GetAll();
        void Add(Oefening oefening);
    }
}