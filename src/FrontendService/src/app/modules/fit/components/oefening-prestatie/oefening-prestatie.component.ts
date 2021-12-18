import { Component, OnInit, Input, ViewChild, AfterViewInit } from '@angular/core';
import { Prestatie } from 'src/app/models/prestatie';
import { OefeningZwaarte } from 'src/app/enums/oefening-zwaarte';

@Component({
  selector: 'app-oefening-prestatie',
  templateUrl: './oefening-prestatie.component.html',
  styleUrls: ['./oefening-prestatie.component.css']
})
export class OefeningPrestatieComponent implements OnInit, AfterViewInit {

  @ViewChild('oefeningZwaarteDot') oefeningZwaarteDot;
  
  @Input() prestatie: Prestatie;

  public oefeningZwaarte: string;
  public showOefeningZwaarte: boolean = true;

  constructor() { }

  ngAfterViewInit(): void {

    if (this.oefeningZwaarteDot === undefined)
      return;

    let element = this.oefeningZwaarteDot.nativeElement;

    switch (this.prestatie.oefeningZwaarte) {
      case OefeningZwaarte.TeZwaar:
        element.classList.add('zwaarte-te-zwaar');
        break;
      case OefeningZwaarte.Goed:
        element.classList.add('zwaarte-goed');
        break;
      case OefeningZwaarte.TeLicht:
        element.classList.add('zwaarte-te-licht');
        break;
    }
  }

  ngOnInit(): void {
    switch (this.prestatie.oefeningZwaarte) {
      case OefeningZwaarte.TeZwaar:
        this.oefeningZwaarte = 'Te zwaar';
        break;
      case OefeningZwaarte.Goed:
        this.oefeningZwaarte = 'Goed';
        break;
      case OefeningZwaarte.TeLicht:
        this.oefeningZwaarte = 'Te licht';
        break;
      default:
        this.showOefeningZwaarte = false;
    }
  }

  
}
