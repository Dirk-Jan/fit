using System;
using System.Collections.Generic;
using BFF.ViewModels;

namespace BFF.Repositories.Abstractions
{
    public interface IWorkoutRepository
    {
        IEnumerable<DateTime> GetAllWorkoutDays(Guid klantId);
        WorkoutViewModel GetWorkoutByDate(Guid klantId, DateTime date);
    }
}