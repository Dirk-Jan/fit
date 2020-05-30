using OefeningService.DAL;
using OefeningService.Models;
using OefeningService.Repositories.Abstractions;

namespace OefeningService.Repositories
{
    public class OefeningRepository : IOefeningRepository
    {
        private readonly OefeningContext _oefeningContext;

        public OefeningRepository(OefeningContext oefeningContext)
        {
            _oefeningContext = oefeningContext;
        }
        
        public void Add(Oefening oefening)
        {
            _oefeningContext.Oefeningen.Add(oefening);
            _oefeningContext.SaveChanges();
        }
    }
}