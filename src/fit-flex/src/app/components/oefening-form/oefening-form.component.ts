import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { OefeningApi } from 'src/app/apis/oefening.api';
import { Oefening } from 'src/app/models/oefening';

@Component({
  selector: 'app-oefening-form',
  templateUrl: './oefening-form.component.html',
  styleUrls: ['./oefening-form.component.css']
})
export class OefeningFormComponent implements OnInit {
  form = new FormGroup({
    naam: new FormControl(),
    omschrijving: new FormControl()
  });

  constructor(private oefeningApi: OefeningApi) { }

  ngOnInit(): void {
  }

  saveOefening() {
    // let oefening = new Oefening();
    // oefening = this.form.value;
    // console.log(oefening);
    this.oefeningApi.add(this.form.value);
    // this.oefeningApi.add(oefening);
  }
}
