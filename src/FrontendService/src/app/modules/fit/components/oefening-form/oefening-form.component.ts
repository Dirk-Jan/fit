import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { OefeningApi } from 'src/app/apis/oefening.api';
import { Router } from '@angular/router';
import { InternalEndpoints } from 'src/app/constants/internal-endpoints';

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

  constructor(
    private oefeningApi: OefeningApi,
    private router: Router
    ) { }

  ngOnInit(): void {
  }

  saveOefening() {
    this.oefeningApi.add(this.form.value)
      .subscribe(x => this.router.navigateByUrl(InternalEndpoints.OefeningenOverzicht));
  }
}
