using System;
using System.Collections.Generic;
using BFF.ViewModels;

namespace BFF.Repositories.Abstractions
{
    public interface IWorkoutRepository
    {
        IEnumerable<DateTime> GetAllWorkoutDays();
        WorkoutViewModel GetWorkoutByDate(DateTime date);
    }
}