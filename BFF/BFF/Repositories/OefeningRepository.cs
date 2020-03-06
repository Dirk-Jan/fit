using System.Collections.Generic;
using System.Linq;
using BFF.DAL;
using BFF.Models;
using BFF.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace BFF.Repositories
{
    public class OefeningRepository : IOefeningRepository
    {
        private readonly BFFContext _context;

        public OefeningRepository(BFFContext context)
        {
            _context = context;
        }

        public IEnumerable<Oefening> GetAll()
        {
            var query = _context.Oefeningen
                .Include(x => x.Prestaties);
            return query.ToList();
        }

        public void Add(Oefening oefening)
        {
            oefening.Prestaties = new List<Prestatie>();
            _context.Oefeningen.Add(oefening);
            _context.SaveChanges();
        }
    }
}