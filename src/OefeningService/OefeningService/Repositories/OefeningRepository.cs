using System.Linq;
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
        
        public void Edit(Oefening oefening)
        {
            var oefeningInDatabase = _oefeningContext.Oefeningen.FirstOrDefault(x => x.Id == oefening.Id);
            if (oefeningInDatabase == null) 
                return;
            
            oefeningInDatabase.Naam = oefening.Naam;
            oefeningInDatabase.Omschrijving = oefening.Omschrijving;
                
            _oefeningContext.SaveChanges();
        }
    }
}