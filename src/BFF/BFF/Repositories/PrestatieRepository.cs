using System;
using System.Collections.Generic;
using System.Linq;
using BFF.DAL;
using BFF.Models;
using BFF.Repositories.Abstractions;

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
    }
}