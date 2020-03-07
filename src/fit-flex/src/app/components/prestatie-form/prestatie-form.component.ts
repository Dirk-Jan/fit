import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-prestatie-form',
  templateUrl: './prestatie-form.component.html',
  styleUrls: ['./prestatie-form.component.css']
})
export class PrestatieFormComponent implements OnInit {
  
  form = new FormGroup({
    gewicht: new FormControl(),
    set1: new FormControl(),
    set2: new FormControl(),
    set3: new FormControl(),
    opmerking: new FormControl()
  });

  constructor() { }

  ngOnInit(): void {
  }

  savePrestatie() {

  }
}
