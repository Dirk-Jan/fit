import { Component, OnInit, Input } from '@angular/core';
import { Prestatie } from 'src/app/models/prestatie';

@Component({
  selector: 'app-vorige-prestaties',
  templateUrl: './vorige-prestaties.component.html',
  styleUrls: ['./vorige-prestaties.component.css']
})
export class VorigePrestatiesComponent implements OnInit {

  @Input() prestaties: Prestatie[];

  constructor() { }

  ngOnInit(): void {
  }

}
