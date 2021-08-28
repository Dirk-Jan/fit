import { Component, OnInit, Input } from '@angular/core';
import { Oefening } from 'src/app/models/oefening';
import { ActivatedRoute, Router } from '@angular/router';
import { OefeningApi } from 'src/app/apis/oefening.api';
import { switchMap } from 'rxjs/operators';
import { InternalEndpoints } from 'src/app/constants/internal-endpoints';
import { RouterPaths } from 'src/app/constants/router-paths';
import { AuthPolicyValidator } from 'src/app/auth/auth-policy-validator';
import { AuthPolicies } from 'src/app/constants/auth-policies';

@Component({
  selector: 'app-oefening',
  templateUrl: './oefening.page.html',
  styleUrls: ['./oefening.page.css']
})
export class OefeningPage implements OnInit {
  readonly oefeningOverzichtUrl: string = InternalEndpoints.OefeningenOverzicht;
  readonly showOefeningEditButton: boolean;

  oefening: Oefening = new Oefening();

  constructor(
    private route: ActivatedRoute,
    private oefeningApi: OefeningApi,
    private router: Router,
    private authPolicyValidator: AuthPolicyValidator
    ) { 
      this.showOefeningEditButton = authPolicyValidator.isAllowed(AuthPolicies.KanOefeningenAanpassenPolicy);
    }

  ngOnInit(): void {
    console.log('nginit called');
    this.route.params.pipe(switchMap(params => this.oefeningApi.getById(params['id'])))
    .subscribe(oefening => 
      {
        console.log(oefening);
        this.oefening = oefening;
      });
  }

  public editOefening() : void {
    this.router.navigate([InternalEndpoints.OefeningBewerken, this.oefening.id]);
  }
}
