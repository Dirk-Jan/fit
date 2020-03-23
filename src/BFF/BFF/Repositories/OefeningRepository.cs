using System;
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
                .OrderBy(oefening => oefening.Naam);
            return query.ToList();
        }

        public Oefening GetById(Guid id)
        {
            return _context.Oefeningen
                .Include(x => x.Prestaties)
                .Single(oefening => oefening.Id == id);
        }

        public void Add(Oefening oefening)
        {
            oefening.Prestaties = new List<Prestatie>();
            _context.Oefeningen.Add(oefening);
            _context.SaveChanges();
        }
    }
}