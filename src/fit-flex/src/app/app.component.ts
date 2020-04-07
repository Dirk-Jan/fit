import { Component } from '@angular/core';
import { AuthService } from './services/auth.service';
import { Router } from '@angular/router';
import { OefeningReadGuard } from './guards/oefening-read.guard';
import { OefeningAddGuard } from './guards/oefening-add.guard';
import { AuthPolicyValidator } from './auth/auth-policy-validator';
import { AuthPolicies } from './constants/auth-policies';
import { AuthPolicy } from './auth/auth-policy';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  isCollapsed: boolean = true;

  readonly showNavNieuweOefeningToevoegen: boolean;
  readonly showNavOefeningOverzicht: boolean;
  readonly userAuthenticated: boolean;
  readonly nameOfUser: string;

  constructor(
    private authService: AuthService, 
    authPolicyValidator: AuthPolicyValidator
    ) {
      console.log('----- Ctor -----');
      this.userAuthenticated = authService.isUserLoggedIn;
      if (this.userAuthenticated) {
        console.log('authenticated');
        this.nameOfUser = authService.name;
        this.showNavOefeningOverzicht = authPolicyValidator.isAllowed(AuthPolicies.KanOefeningenZienPolicy);
        this.showNavNieuweOefeningToevoegen = authPolicyValidator.isAllowed(AuthPolicies.KanOefeningenToevoegenPolicy);
      }
      console.log('----- ctor done -----');
  }

  // get isUserLoggedIn() : boolean {
  //   return this.authService.isUserLoggedIn;
  // }

  // get name() : string {
  //   return this.authService.name;
  // }

  login() {
    this.authService.login();
  }

  logout() {
    this.authService.logout();
  }

  register() {
    window.location.href = "http://localhost:5000/Account/Register"
  }

  // get showNavNieuweOefeningToevoegen() {
  //   console.log('checking toevoegen');
  //   return true;
  //   // return this.authPolicyValidator.isAllowed(AuthPolicies.KanOefeningenToevoegenPolicy);
  // }

  // get showNavOefeningOverzicht() {
  //   console.log('checking zien');
  //   // return this.authPolicyValidator.isAllowed(AuthPolicies.KanOefeningenZienPolicy);
  //   return true;
  // }
}