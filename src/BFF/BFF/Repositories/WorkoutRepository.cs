using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BFF.DAL;
using BFF.Models;
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

        public IEnumerable<DateTime> GetAllWorkoutDays(Guid klantId)
        {
            var query = _context.Prestaties
                .Where(p => p.KlantId == klantId)
                .GroupBy(p => p.Datum.Date)
                .OrderByDescending(grp => grp.Key)
                .Select(grp => grp.Key);
            return query.ToList();
        }

        public WorkoutViewModel GetWorkoutByDate(Guid klantId, DateTime date)
        {
            var query = from oefening in _context.Oefeningen
                join prestatie in _context.Prestaties on oefening.Id equals prestatie.OefeningId
                where prestatie.Datum.Date == date.Date && prestatie.KlantId == klantId
                orderby prestatie.Datum.Date descending
                select new
                {
                    Oefening = oefening,
                    Prestatie = prestatie
                };

            var workoutItems = new List<WorkoutItemViewModel>();
            var results = query.ToList();
            Oefening lastOefening = null;
            foreach (var result in results)
            {
                if (lastOefening != null && lastOefening.Id == result.Oefening.Id)
                {
                    workoutItems.Last().Prestaties.Add(result.Prestatie);
                }
                else
                {
                    workoutItems.Add(new WorkoutItemViewModel
                    {
                        OefeningId = result.Oefening.Id,
                        OefeningNaam = result.Oefening.Naam,
                        Prestaties = new List<Prestatie>
                        {
                            result.Prestatie
                        }
                    });
                    lastOefening = result.Oefening;
                }
            }

            return new WorkoutViewModel
            {
                Datum = date.Date,
                WorkoutItems = workoutItems
            };
        }
    }
}