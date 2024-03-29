﻿using System.Linq;
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
            _oefeningContext.Oefeningen.Update(oefening);
            
            // _oefeningContext.Oefeningen.Attach(oefening);
            // _oefeningContext.Entry(oefening).Property(x => x.Naam).IsModified = true;
            // _oefeningContext.Entry(oefening).Property(x => x.Omschrijving).IsModified = true;
            //
            // var oefeningInDatabase = _oefeningContext.Oefeningen.First(x => x.Id == oefening.Id);
            // oefeningInDatabase.Naam = oefening.Naam;
            // oefeningInDatabase.Omschrijving = oefening.Omschrijving;
            
            _oefeningContext.SaveChanges();
        }
    }
}