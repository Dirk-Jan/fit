import { Component, OnInit } from '@angular/core';
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
export class AppComponent implements OnInit {
  isCollapsed: boolean = true;

  readonly showNavNieuweOefeningToevoegen: boolean;
  readonly showNavOefeningOverzicht: boolean;
   userAuthenticated: boolean;
   nameOfUser: string;

  constructor(
    private authService: AuthService, 
    authPolicyValidator: AuthPolicyValidator
    ) {
      // setTimeout(() => {
      //   console.log('setting name of user....');
      //   this.userAuthenticated = this.authService.isUserLoggedIn;
      //   this.nameOfUser = this.authService.name;
      // }, 2000);
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

  ngOnInit(): void {
    // this.userAuthenticated = true;
    // this.nameOfUser = this.authService.name;
  }

  login() {
    this.authService.login();
  }

  logout() {
    this.authService.logout();
  }

  register() {
    window.location.href = "http://localhost:5000/Account/Register"
  }
}