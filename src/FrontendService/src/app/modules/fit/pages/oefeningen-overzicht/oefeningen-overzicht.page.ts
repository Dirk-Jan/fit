import { Component, OnInit } from '@angular/core';
import { Prestatie } from 'src/app/models/prestatie';
import { Oefening } from 'src/app/models/oefening';
import { ThrowStmt } from '@angular/compiler';
import { OefeningApi } from 'src/app/apis/oefening.api';
import { InternalEndpoints } from 'src/app/constants/internal-endpoints';
import { Spiergroep } from 'src/app/enums/spiergroep';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-oefeningen-overzicht.page',
  templateUrl: './oefeningen-overzicht.page.html',
  styleUrls: ['./oefeningen-overzicht.page.css']
})
export class OefeningenOverzichtPage implements OnInit {
  readonly oefeningDetailsUrl: string = InternalEndpoints.OefeningDetails;

  selectedSpiergroep = 'all';
  oefeningen: Oefening[];
  private allOefeningen: Oefening[];
  
  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private router: Router,
    private oefeningApi: OefeningApi
    ) { }

  ngOnInit(): void {
    

    console.log('Calling api');
    this.oefeningApi.query().subscribe(oefeningen => {
      this.oefeningen = oefeningen;
      this.allOefeningen = oefeningen;
      console.log('Nieuwe oefeningen: ', oefeningen);

      this.fetchSpiergroepParam();
    });
  }

  private fetchSpiergroepParam(): void {
    this.route.queryParams.subscribe(params => {
      // this.name = params['name'];
      console.log('spiergroep filter param:', params['spiergroep']);

      if (this.spiergroepParamIsValid(params['spiergroep'])) {
        console.log('spiergroep param valid');
        this.selectedSpiergroep = params['spiergroep'];
        this.spiergroepOnSelectionChanged(this.selectedSpiergroep);
      }
    });
  }

  spiergroepOnSelectionChanged(value) : void {
    console.log('spiergroepOnSelectionChanged called');
    if (value === 'all') {
      this.oefeningen = this.allOefeningen;
    } else if (value == 'uncategorized') {
      this.filterByNoSpiergroep();
    } else {
      let valueAsEnum = value as Spiergroep;
      this.filterSpiergroep(valueAsEnum);
    }
    
    const url = this.router.createUrlTree([], {relativeTo: this.route, queryParams: {spiergroep: value}}).toString();

    this.location.go(url);
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

  private spiergroepParamIsValid(value) : boolean {
    switch (value) {
      case 'all':
      case 'uncategorized':
      case '0':
      case '1':
      case '2':
      case '3':
      case '4':
      case '5':
      case '6':
        return true;
      default:
        return false;
    }
  }
}
