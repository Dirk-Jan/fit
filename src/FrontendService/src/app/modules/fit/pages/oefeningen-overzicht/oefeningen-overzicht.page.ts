import { Component, OnInit } from '@angular/core';
import { Prestatie } from 'src/app/models/prestatie';
import { Oefening } from 'src/app/models/oefening';
import { ThrowStmt } from '@angular/compiler';
import { OefeningApi } from 'src/app/apis/oefening.api';
import { InternalEndpoints } from 'src/app/constants/internal-endpoints';
import { Spiergroep } from 'src/app/enums/spiergroep';

@Component({
  selector: 'app-oefeningen-overzicht.page',
  templateUrl: './oefeningen-overzicht.page.html',
  styleUrls: ['./oefeningen-overzicht.page.css']
})
export class OefeningenOverzichtPage implements OnInit {
  readonly oefeningDetailsUrl: string = InternalEndpoints.OefeningDetails;

  selected = 'all';
  oefeningen: Oefening[];
  private allOefeningen: Oefening[];
  
  constructor(private oefeningApi: OefeningApi) { }

  ngOnInit(): void {
    console.log('Calling api');
    this.oefeningApi.query().subscribe(oefeningen => {
      this.oefeningen = oefeningen;
      this.allOefeningen = oefeningen;
      console.log('Nieuwe oefeningen: ', oefeningen);
    });
  }

  spiergroepOnSelectionChanged(value) : void {
    if (value === 'all') {
      this.oefeningen = this.allOefeningen;
    } else if (value == 'uncategorized') {
      this.filterByNoSpiergroep();
    } else {
      let valueAsEnum = value as Spiergroep;
      this.filterSpiergroep(valueAsEnum);
    }
    
  }

  private filterSpiergroep(spiergroep: Spiergroep): void {
    
    let oefeningen: Oefening[] = [];
    for (let i=0; i<this.allOefeningen.length; i++) {
      if (this.allOefeningen[i].spiergroep == spiergroep) {
        oefeningen.push(this.allOefeningen[i]);
      }
    }

    this.oefeningen = oefeningen;
  }

  private filterByNoSpiergroep(): void {
    let oefeningen: Oefening[] = [];
    for (let i=0; i<this.allOefeningen.length; i++) {
      if (this.allOefeningen[i].spiergroep === undefined || this.allOefeningen[i].spiergroep === null ) {
        oefeningen.push(this.allOefeningen[i]);
      }
    }

    this.oefeningen = oefeningen;
  }

}
