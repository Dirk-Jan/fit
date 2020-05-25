using System;
using System.Collections;
using System.Collections.Generic;
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
        [Route("{workoutDatum}")]
        public IActionResult GetWorkoutByDate(DateTime date)
        {
            var workout = _workoutRepository.GetWorkoutByDate(date);
            return Json(workout);
        }
    }
}