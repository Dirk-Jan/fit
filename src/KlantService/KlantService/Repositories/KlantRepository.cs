using KlantService.DAL;
using KlantService.Models;
using KlantService.Repositories.Abstractions;

namespace KlantService.Repositories
{
    public class KlantRepository : IKlantRepository
    {
        private readonly KlantContext _klantContext;

        public KlantRepository(KlantContext klantContext)
        {
            _klantContext = klantContext;
        }
        
        public void Add(Klant klant)
        {
            _klantContext.Klanten.Add(klant);
            _klantContext.SaveChanges();
        }
    }
}