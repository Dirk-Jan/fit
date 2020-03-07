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
    }
}