import { Component, OnInit, Input } from '@angular/core';
import { Prestatie } from 'src/app/models/prestatie';

@Component({
  selector: 'app-oefening-prestatie',
  templateUrl: './oefening-prestatie.component.html',
  styleUrls: ['./oefening-prestatie.component.css']
})
export class OefeningPrestatieComponent implements OnInit {

  @Input() prestatie: Prestatie;
  // = {
  //   date: null,
  //   gewicht: 6,
  //   set1: 15,
  //   set2: 15,
  //   set3: 15
  // } as Prestatie;

  constructor() { }

  ngOnInit(): void {
  }

}
