import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { InternalEndpoints } from 'src/app/constants/internal-endpoints';
import { PrestatieDag } from 'src/app/models/prestatie-dag';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-prestatie-dag',
  templateUrl: './prestatie-dag.component.html',
  styleUrls: ['./prestatie-dag.component.css']
})
export class PrestatieDagComponent implements OnInit {

  @Input() prestatieDag: PrestatieDag;

  constructor(private router: Router, private datePipe: DatePipe) { }

  ngOnInit(): void {
  }

  public goToWorkoutDag(): void {
    let formattedDate = this.datePipe.transform(this.prestatieDag.datum, 'YYYY-MM-dd');
    this.router.navigateByUrl(`${InternalEndpoints.workoutDetails}/${formattedDate}`);
  }
}
