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
    public class WorkoutController : BaseController
    {
        private readonly IWorkoutRepository _workoutRepository;
        
        public WorkoutController(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }
        
        [HttpGet]
        public IActionResult GetAllWorkoutDatums()
        {
            var klantId = GetKlantIdFromToken();
            var workoutDatums = _workoutRepository.GetAllWorkoutDays(klantId);
            return Json(workoutDatums);
        }

        [HttpGet]
        [Route("{workoutDatumString}")]
        public IActionResult GetWorkoutByDate(string workoutDatumString)
        {
            var date = DateTime.ParseExact(workoutDatumString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var klantId = GetKlantIdFromToken();
            var workout = _workoutRepository.GetWorkoutByDate(klantId, date);
            return Json(workout);
        }
    }
}