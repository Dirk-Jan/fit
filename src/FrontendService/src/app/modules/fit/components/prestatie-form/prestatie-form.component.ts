import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { OefeningApi } from 'src/app/apis/oefening.api';
import { Oefening } from 'src/app/models/oefening';
import { Router } from '@angular/router';

@Component({
  selector: 'app-prestatie-form',
  templateUrl: './prestatie-form.component.html',
  styleUrls: ['./prestatie-form.component.css']
})
export class PrestatieFormComponent implements OnInit {

  @Input() oefening: Oefening;

  form = new FormGroup({
    gewicht: new FormControl(),
    herhalingen: new FormControl(),
    sets: new FormControl(),
    opmerking: new FormControl()
  });

  // gewichtFormControl = new FormControl(0,
  //   [
  //     Validators.min(0),
  //     Validators.required
  //   ]
  // );

  // herhalingenFormControl = new FormControl(0,
  //   [
  //     Validators.min(0),
  //     Validators.required
  //   ]
  // );

  // opmerkingFormControl = new FormControl();

  constructor(
    private oefeningApi: OefeningApi,
    private router: Router
    ) { }

  ngOnInit(): void {
  }

  savePrestatie() {
    this.oefeningApi.addPrestatie(this.oefening, this.form.value)
      .subscribe(x => window.location.reload());
  }
}
