import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { OefeningApi } from 'src/app/apis/oefening.api';
import { Oefening } from 'src/app/models/oefening';
import { Router } from '@angular/router';
import { Endpoints } from 'src/app/constants/endpoints';

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
                    .subscribe(x => this.router.navigateByUrl('/fit/' + Endpoints.OefeningenOverzicht));
  }
}
