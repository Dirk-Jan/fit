import { Component, OnInit, Input } from '@angular/core';
import { PrestatieDag } from 'src/app/models/prestatie-dag';

@Component({
  selector: 'app-vorige-prestaties',
  templateUrl: './vorige-prestaties.component.html',
  styleUrls: ['./vorige-prestaties.component.css']
})
export class VorigePrestatiesComponent implements OnInit {

  @Input() prestatieDagen: PrestatieDag[];

  constructor() { }

  ngOnInit(): void {
  }

}
