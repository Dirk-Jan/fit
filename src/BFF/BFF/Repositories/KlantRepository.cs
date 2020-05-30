using BFF.DAL;
using BFF.Models;
using BFF.Repositories.Abstractions;

namespace BFF.Repositories
{
    public class KlantRepository : IKlantRepository
    {
        private readonly BFFContext _context;
        
        public KlantRepository(BFFContext context)
        {
            _context = context;
        }
        
        public void AddKlant(Klant klant)
        {
            _context.Klanten.Add(klant);
            _context.SaveChanges();
        }
    }
}