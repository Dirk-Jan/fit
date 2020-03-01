import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

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

  constructor() { }

  ngOnInit(): void {
  }

  saveOefening() {
    console.log(this.form.value);
  }
}
