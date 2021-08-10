import { Component, OnInit, Input } from '@angular/core';
import { Oefening } from 'src/app/models/oefening';
import { ActivatedRoute, Router } from '@angular/router';
import { OefeningApi } from 'src/app/apis/oefening.api';
import { switchMap } from 'rxjs/operators';
import { InternalEndpoints } from 'src/app/constants/internal-endpoints';

@Component({
  selector: 'app-oefening-bewerken',
  templateUrl: './oefening-bewerken.page.html',
  styleUrls: ['./oefening-bewerken.page.css']
})
export class OefeningBewerkenPage implements OnInit {

  oefening: Oefening = new Oefening();

  constructor(
    private route: ActivatedRoute,
    private oefeningApi: OefeningApi,
    private router: Router
    ) { }

  ngOnInit(): void {
    this.route.params.pipe(switchMap(params => this.oefeningApi.getById(params['id'])))
    .subscribe(oefening => 
      {
        console.log(oefening);
        this.oefening = oefening;
      });
  }

  public oefeningSubmitted(oefening: Oefening) : void {
    console.log('Oefening aangepast', oefening);
    // this.oefeningApi.add(oefening)
    //   .subscribe(x => this.router.navigateByUrl(InternalEndpoints.OefeningenOverzicht));
  }

  public formCancelled() : void {
    this.router.navigate([InternalEndpoints.OefeningDetails, this.oefening.id]);
  }
}
