import { Component, OnInit, Input } from '@angular/core';
import { Prestatie } from 'src/app/models/prestatie';
import { PrestatieDag } from 'src/app/models/prestatie-dag';

@Component({
  selector: 'app-vorige-prestaties',
  templateUrl: './vorige-prestaties.component.html',
  styleUrls: ['./vorige-prestaties.component.css']
})
export class VorigePrestatiesComponent implements OnInit {

  @Input() prestatieDagen: PrestatieDag[];
  // private _pres;

  // @Input() prestaties: Prestatie[];
  // @Input()
  // set prestaties(val: Prestatie[]) {
  //   console.log(this.prestaties);
  //   this._pres = this.prestaties;
  //   let prestatieDag = new PrestatieDag();
  //   prestatieDag.datum = new Date();
  //   prestatieDag.prestaties = val;
  //   this.prestatieDagen = [prestatieDag];
  // }

  constructor() { }

  ngOnInit(): void {
  }

}
