import { Component, OnInit, Input } from '@angular/core';
import { PrestatieDag } from 'src/app/models/prestatie-dag';

@Component({
  selector: 'app-prestatie-dag',
  templateUrl: './prestatie-dag.component.html',
  styleUrls: ['./prestatie-dag.component.css']
})
export class PrestatieDagComponent implements OnInit {

  @Input() prestatieDag: PrestatieDag;

  constructor() { }

  ngOnInit(): void {
  }

}
