using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BFF.DAL;
using BFF.Repositories.Abstractions;
using BFF.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BFF.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly BFFContext _context;

        public WorkoutRepository(BFFContext context)
        {
            _context = context;
        }

        public IEnumerable<DateTime> GetAllWorkoutDays()
        {
            var query = _context.Prestaties
                .GroupBy(p => p.Datum.Date)
                .OrderByDescending(grp => grp.Key)
                .Select(grp => grp.Key);
            return query.ToList();
        }

        public WorkoutViewModel GetWorkoutByDate(DateTime date)
        {
            var query = from oefening in _context.Oefeningen
                join prestatie in _context.Prestaties on oefening.Id equals prestatie.OefeningId
                where prestatie.Datum.Date == date.Date
                orderby prestatie.Datum.Date descending
                select new WorkoutItemViewModel
                {
                    OefeningNaam = oefening.Naam,
                    Prestatie = prestatie
                };

            return new WorkoutViewModel
            {
                Datum = date.Date,
                WorkoutItems = query.ToList()
            };
        }
    }
}