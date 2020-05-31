using System;
using System.Collections.Generic;
using System.Linq;
using BFF.DAL;
using BFF.Models;
using BFF.Repositories.Abstractions;
using BFF.ViewModels;

namespace BFF.Repositories
{
    public class PrestatieRepository : IPrestatieRepository
    {
        private readonly BFFContext _context;

        public PrestatieRepository(BFFContext context)
        {
            _context = context;
        }
        
        public void Add(Prestatie prestatie)
        {
            _context.Prestaties.Add(prestatie);
            _context.SaveChanges();
        }

        public IEnumerable<Prestatie> GetByOefeningId(Guid oefeningId)
        {
            var query = _context.Prestaties.Where(x => x.OefeningId == oefeningId)
                .OrderByDescending(x => x.Datum);
            return query.ToList();
        }

        public IEnumerable<PrestatieDag> GetLatestsXDays(Guid oefeningId, Guid klantId, int dayAmount)
        {
            var query = _context.Prestaties.Where(x => x.OefeningId == oefeningId && x.KlantId == klantId)
                .ToList()
                .GroupBy(x => x.Datum.Date)
                .OrderByDescending(group => group.Key)
                .Take(dayAmount);

            var prestatieDagen = new List<PrestatieDag>();
            foreach (var group in query)
            {
                prestatieDagen.Add(new PrestatieDag
                {
                    Datum = group.Key,
                    Prestaties = group
                });
            }

            return prestatieDagen;
        }
    }
}