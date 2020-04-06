import { Component } from '@angular/core';
import { AuthService } from './services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'fit-flex';
  isCollapsed: boolean = true;

  constructor(private authService: AuthService) {}

  get isUserLoggedIn() : boolean {
    return this.authService.isUserLoggedIn;
  }

  get name() : string {
    return this.authService.name;
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