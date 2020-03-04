import { Component, OnInit } from '@angular/core';
import { Prestatie } from 'src/app/models/prestatie';

@Component({
  selector: 'app-oefening',
  templateUrl: './oefening.component.html',
  styleUrls: ['./oefening.component.css']
})
export class OefeningComponent implements OnInit {

  prestaties: Prestatie[] = [
    {
      date: null,
      gewicht: 6,
      set1: 15,
      set2: 15,
      set3: 15,
      opmerking: 'te zwaar :('
    },
    {
      date: null,
      gewicht: 6,
      set1: 15,
      set2: 15,
      set3: 15,
      opmerking: 'te zwaar :('
    },
    {
      date: null,
      gewicht: 6,
      set1: 15,
      set2: 15,
      set3: 15,
      opmerking: 'te zwaar :('
    }
  ] as Prestatie[];

  constructor() { }

  ngOnInit(): void {
  }

}
