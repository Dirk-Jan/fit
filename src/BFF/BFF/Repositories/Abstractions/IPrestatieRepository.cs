using System;
using System.Collections.Generic;
using BFF.Models;
using BFF.ViewModels;

namespace BFF.Repositories.Abstractions
{
    public interface IPrestatieRepository
    {
        void Add(Prestatie prestatie);
        IEnumerable<Prestatie> GetByOefeningId(Guid oefeningId);
        IEnumerable<PrestatieDag> GetLatestsXDays(Guid oefeningId, Guid klantId, int dayAmount);
    }
}