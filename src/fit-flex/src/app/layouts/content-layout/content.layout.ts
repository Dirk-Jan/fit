import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { AuthPolicyValidator } from 'src/app/auth/auth-policy-validator';
import { AuthPolicies } from 'src/app/constants/auth-policies';

@Component({
    selector: 'app-content-layout',
    templateUrl: './content.layout.html',
    styleUrls: ['./content.layout.css']
  })
  export class ContentLayout implements OnInit {
    isCollapsed: boolean = true;
  
    readonly showNavNieuweOefeningToevoegen: boolean;
    readonly showNavOefeningOverzicht: boolean;
    readonly nameOfUser: string;
  
    constructor(
      private authService: AuthService, 
      authPolicyValidator: AuthPolicyValidator
      ) {
        console.log('----- Ctor -----');

        console.log('authenticated');
        this.nameOfUser = authService.name;
        this.showNavOefeningOverzicht = authPolicyValidator.isAllowed(AuthPolicies.KanOefeningenZienPolicy);
        this.showNavNieuweOefeningToevoegen = authPolicyValidator.isAllowed(AuthPolicies.KanOefeningenToevoegenPolicy);

        console.log('----- ctor done -----');
    }
  
    ngOnInit(): void {}
  
    logout() {
      this.authService.logout();
    }
  }