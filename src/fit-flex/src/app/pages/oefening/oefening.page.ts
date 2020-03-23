import { Component, OnInit, Input } from '@angular/core';
import { Oefening } from 'src/app/models/oefening';
import { ActivatedRoute } from '@angular/router';
import { OefeningApi } from 'src/app/apis/oefening.api';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-oefening',
  templateUrl: './oefening.page.html',
  styleUrls: ['./oefening.page.css']
})
export class OefeningPage implements OnInit {

  oefening: Oefening = new Oefening();

  constructor(
    private route: ActivatedRoute,
    private oefeningApi: OefeningApi
    ) { }

  ngOnInit(): void {
    console.log('nginit called');
    this.route.params.pipe(switchMap(params => this.oefeningApi.getById(params['id'])))
    .subscribe(oefening => this.oefening = oefening);
  }

}
