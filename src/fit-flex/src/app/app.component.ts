import { Component } from '@angular/core';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'fit-flex';
  isCollapsed: boolean = true;

  constructor(private authService:AuthService) {}

  get isUserLoggedIn() : boolean {
    return this.authService.isUserLoggedIn;
  }

  login() {
    console.log('logging in...');
    this.authService.login();
  }

  logout() {
    this.authService.logout();
  }

  register() {
    
  }
}