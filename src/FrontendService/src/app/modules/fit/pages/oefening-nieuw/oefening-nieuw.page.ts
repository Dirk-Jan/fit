import { Component, OnInit, Input } from '@angular/core';
import { Oefening } from 'src/app/models/oefening';
import { ActivatedRoute, Router } from '@angular/router';
import { OefeningApi } from 'src/app/apis/oefening.api';
import { switchMap } from 'rxjs/operators';
import { InternalEndpoints } from 'src/app/constants/internal-endpoints';
import { connectableObservableDescriptor } from 'rxjs/internal/observable/ConnectableObservable';

@Component({
  selector: 'app-oefening-nieuw',
  templateUrl: './oefening-nieuw.page.html',
  styleUrls: ['./oefening-nieuw.page.css']
})
export class OefeningNieuwPage implements OnInit {

  oefening: Oefening = new Oefening();

  constructor(
    private oefeningApi: OefeningApi,
    private router: Router
    ) { }

  ngOnInit(): void {
  }

  public oefeningSubmitted(oefening: Oefening) : void {
    console.log('Oefening submitted', oefening);
    this.oefeningApi.add(oefening)
      .subscribe(oefeningId => this.router.navigate([InternalEndpoints.OefeningDetails, oefeningId]));
  }

  public formCancelled() : void {
    console.log('cancel clicked');
    this.router.navigate([InternalEndpoints.FitModule]);
  }
}
