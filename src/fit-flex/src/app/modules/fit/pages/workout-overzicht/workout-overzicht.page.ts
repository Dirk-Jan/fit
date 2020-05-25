import { Component, OnInit } from '@angular/core';
import { Prestatie } from 'src/app/models/prestatie';
import { Oefening } from 'src/app/models/oefening';
import { ThrowStmt } from '@angular/compiler';
import { OefeningApi } from 'src/app/apis/oefening.api';
import { InternalEndpoints } from 'src/app/constants/internal-endpoints';
import { Workout } from 'src/app/models/workout';
import { WorkoutApi } from 'src/app/apis/workout.api';

@Component({
  selector: 'app-workout-overzicht.page',
  templateUrl: './workout-overzicht.page.html',
  styleUrls: ['./workout-overzicht.page.css']
})
export class WorkoutOverzichtPage implements OnInit {
  readonly workoutDetailsUrl: string = InternalEndpoints.workoutDetails;

  workoutsDatums: Date[];
  
  constructor(private workoutApi: WorkoutApi) { }

  ngOnInit(): void {
    console.log('Calling api');
    this.workoutApi.getAllWorkoutDatums().subscribe(workoutsDatums => {
      this.workoutsDatums = workoutsDatums;
      console.log('Nieuwe workouts: ', workoutsDatums);
    });
  }

}
