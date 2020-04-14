import { Component, OnInit } from '@angular/core';
import { Prestatie } from 'src/app/models/prestatie';
import { Oefening } from 'src/app/models/oefening';
import { ThrowStmt } from '@angular/compiler';
import { OefeningApi } from 'src/app/apis/oefening.api';
import { InternalEndpoints } from 'src/app/constants/internal-endpoints';

@Component({
  selector: 'app-oefeningen-overzicht.page',
  templateUrl: './oefeningen-overzicht.page.html',
  styleUrls: ['./oefeningen-overzicht.page.css']
})
export class OefeningenOverzichtPage implements OnInit {
  readonly oefeningDetailsUrl: string = InternalEndpoints.OefeningDetails;

  oefeningen: Oefening[];
  
  constructor(private oefeningApi: OefeningApi) { }

  ngOnInit(): void {
    console.log('Calling api');
    this.oefeningApi.query().subscribe(oefeningen => {
      this.oefeningen = oefeningen;
      console.log('Nieuwe oefeningen: ', oefeningen);
    });
  }

}
