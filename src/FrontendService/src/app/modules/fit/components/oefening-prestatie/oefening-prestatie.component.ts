import { Component, OnInit, Input } from '@angular/core';
import { KeyValuePipe } from '@angular/common';
import { Prestatie } from 'src/app/models/prestatie';
import { OefeningZwaarte } from 'src/app/enums/oefening-zwaarte';

@Component({
  selector: 'app-oefening-prestatie',
  templateUrl: './oefening-prestatie.component.html',
  styleUrls: ['./oefening-prestatie.component.css']
})
export class OefeningPrestatieComponent implements OnInit {

  @Input() prestatie: Prestatie;

  public oefeningZwaarte: string;

  constructor() { }

  ngOnInit(): void {
    // console.log('pre')
    // this.oefeningZwaarte = 'aaaaaaaa';
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
    }
  }

}
