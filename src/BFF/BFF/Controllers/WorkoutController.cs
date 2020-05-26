using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using BFF.Constants;
using BFF.Repositories.Abstractions;
using BFF.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BFF.Controllers
{
    [ApiController]
    [Route(Routes.Workouts)]
    public class WorkoutController : Controller
    {
        private readonly IWorkoutRepository _workoutRepository;
        
        public WorkoutController(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }
        
        [HttpGet]
        public IActionResult GetAllWorkoutDatums()
        {
            var workoutDatums = _workoutRepository.GetAllWorkoutDays();
            return Json(workoutDatums);
        }

        [HttpGet]
        [Route("{workoutDatumString}")]
        public IActionResult GetWorkoutByDate(string workoutDatumString)
        {
            var date = DateTime.ParseExact(workoutDatumString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var workout = _workoutRepository.GetWorkoutByDate(date);
            return Json(workout);
        }
    }
}