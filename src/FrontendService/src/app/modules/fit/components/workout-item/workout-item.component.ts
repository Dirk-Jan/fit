import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { InternalEndpoints } from 'src/app/constants/internal-endpoints';
import { WorkoutItem } from 'src/app/models/workout-item';

@Component({
  selector: 'app-workout-item',
  templateUrl: './workout-item.component.html',
  styleUrls: ['./workout-item.component.css']
})
export class WorkoutItemComponent implements OnInit {

  @Input() workoutItem: WorkoutItem;

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  public goToOefening(): void {
    this.router.navigateByUrl(`${InternalEndpoints.OefeningDetails}/${this.workoutItem.oefeningId}`);
  }
}
