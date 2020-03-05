import { Component, OnInit } from '@angular/core';
import { Prestatie } from 'src/app/models/prestatie';
import { Oefening } from 'src/app/models/oefening';
import { ThrowStmt } from '@angular/compiler';

@Component({
  selector: 'app-oefeningen-overzicht.page',
  templateUrl: './oefeningen-overzicht.page.html',
  styleUrls: ['./oefeningen-overzicht.page.css']
})
export class OefeningenOverzichtPage implements OnInit {

  prestaties: Prestatie[] = [
    {
      datum: new Date('1968-11-16T00:00:00'),
      gewicht: 6,
      set1: 15,
      set2: 15,
      set3: 15,
      opmerking: 'te zwaar :('
    },
    {
      datum: new Date('2020-02-24T12:15:00'),
      gewicht: 6,
      set1: 15,
      set2: 15,
      set3: 15,
      opmerking: 'te zwaar :('
    },
    {
      datum: new Date('2020-02-26T12:15:00'),
      gewicht: 6,
      set1: 15,
      set2: 15,
      set3: 15,
      opmerking: 'te zwaar :('
    }
  ];

  oefeningen: Oefening[] = [
    {
      naam: 'Benchpress',
      omschrijving: 'met een horizontale paal',
      prestaties: this.prestaties,
    },
    {
      naam: 'Walking lunges',
      omschrijving: 'met gewicht',
      prestaties: this.prestaties,
    },
    {
      naam: 'Chest press',
      omschrijving: '',
      prestaties: this.prestaties,
    },
  ];

  
  
  constructor() { }

  ngOnInit(): void {
  }

}
