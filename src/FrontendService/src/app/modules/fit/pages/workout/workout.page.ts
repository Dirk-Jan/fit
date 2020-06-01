import { Component, OnInit, Input } from '@angular/core';
import { Oefening } from 'src/app/models/oefening';
import { ActivatedRoute } from '@angular/router';
import { OefeningApi } from 'src/app/apis/oefening.api';
import { switchMap } from 'rxjs/operators';
import { InternalEndpoints } from 'src/app/constants/internal-endpoints';
import { Workout } from 'src/app/models/workout';
import { WorkoutApi } from 'src/app/apis/workout.api';

@Component({
  selector: 'app-workout',
  templateUrl: './workout.page.html',
  styleUrls: ['./workout.page.css']
})
export class WorkoutPage implements OnInit {
  readonly workoutOverzichtUrl: string = InternalEndpoints.workoutOverzicht;

  workout: Workout = new Workout();

  constructor(
    private route: ActivatedRoute,
    private workoutApi: WorkoutApi
    ) { }

  ngOnInit(): void {
    console.log('nginit called');
    this.route.params.pipe(switchMap(params => this.workoutApi.getById(params['workoutDag'])))
    .subscribe(workout => 
      {
        console.log(workout);
        this.workout = workout;
      });
  }

}
