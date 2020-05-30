using PrestatieService.DAL;
using PrestatieService.Models;
using PrestatieService.Repositories.Abstractions;

namespace PrestatieService.Repositories
{
    public class PrestatieRepository : IPrestatieRepository
    {
        private readonly PrestatieContext _prestatieContext;

        public PrestatieRepository(PrestatieContext prestatieContext)
        {
            _prestatieContext = prestatieContext;
        }
        
        public void Add(Prestatie prestatie)
        {
            _prestatieContext.Prestaties.Add(prestatie);
            _prestatieContext.SaveChanges();
        }
    }
}