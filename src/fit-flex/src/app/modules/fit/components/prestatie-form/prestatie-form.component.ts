import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { OefeningApi } from 'src/app/apis/oefening.api';
import { Oefening } from 'src/app/models/oefening';
import { Prestatie } from 'src/app/models/prestatie';
import { Router } from '@angular/router';
import { Endpoints } from 'src/app/constants/endpoints';

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
    opmerking: new FormControl()
  });

  constructor(
    private oefeningApi: OefeningApi,
    private router: Router
    ) { }

  ngOnInit(): void {
  }

  savePrestatie() {
    console.log('mijn form value ', this.form.value);
    this.oefeningApi.addPrestatie(this.oefening, this.form.value)
      .subscribe(x => this.router.navigateByUrl('/fit/' + Endpoints.OefeningDetails + '/' + this.oefening.id));
  }
}
