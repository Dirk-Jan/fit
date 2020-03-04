import { Component, OnInit, Input } from '@angular/core';
import { Prestatie } from 'src/app/models/prestatie';
import { Oefening } from 'src/app/models/oefening';

@Component({
  selector: 'app-oefening',
  templateUrl: './oefening.component.html',
  styleUrls: ['./oefening.component.css']
})
export class OefeningComponent implements OnInit {

  @Input() oefening: Oefening;

  constructor() { }

  ngOnInit(): void {
  }

}
