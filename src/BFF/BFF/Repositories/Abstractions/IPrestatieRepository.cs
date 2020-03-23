using System;
using System.Collections.Generic;
using BFF.Models;

namespace BFF.Repositories.Abstractions
{
    public interface IPrestatieRepository
    {
        void Add(Prestatie prestatie);
        IEnumerable<Prestatie> GetByOefeningId(Guid oefeningId);
    }
}