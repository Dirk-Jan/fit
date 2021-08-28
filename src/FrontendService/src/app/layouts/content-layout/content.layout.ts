import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { AuthPolicyValidator } from 'src/app/auth/auth-policy-validator';
import { AuthPolicies } from 'src/app/constants/auth-policies';
import { InternalEndpoints } from 'src/app/constants/internal-endpoints';

@Component({
    selector: 'app-content-layout',
    templateUrl: './content.layout.html',
    styleUrls: ['./content.layout.css']
  })
  export class ContentLayout implements OnInit {
    readonly fitModuleUrl: string = InternalEndpoints.FitModule;
    readonly oefeningOverzichtUrl: string = InternalEndpoints.OefeningenOverzicht;
    readonly nieuweOefeningUrl: string = InternalEndpoints.NieuweOefening;
    readonly workoutOverzichtUrl: string = InternalEndpoints.workoutOverzicht;

    isCollapsed: boolean = true;
  
    readonly showNavNieuweOefeningToevoegen: boolean;
    readonly showNavOefeningOverzicht: boolean;
    readonly showNavWorkoutOverzicht: boolean;
    readonly nameOfUser: string;
  
    constructor(
      private authService: AuthService, 
      authPolicyValidator: AuthPolicyValidator
      ) {
        this.nameOfUser = authService.name;
        this.showNavOefeningOverzicht = authPolicyValidator.isAllowed(AuthPolicies.KanOefeningenZienPolicy);
        this.showNavNieuweOefeningToevoegen = authPolicyValidator.isAllowed(AuthPolicies.KanOefeningenToevoegenPolicy);
        this.showNavWorkoutOverzicht = authPolicyValidator.isAllowed(AuthPolicies.KanOefeningenZienPolicy);
    }
  
    ngOnInit(): void {}
  
    logout() {
      this.authService.logout();
    }
  }