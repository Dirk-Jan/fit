import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
    selector: 'app-landing-page',
    templateUrl: './landing-page.page.html',
    styleUrls: ['./landing-page.page.css']
  })
  export class LandingPagePage implements OnInit {
  
    constructor(
      private authService: AuthService
      ) {
    }
  
    ngOnInit(): void {}

    login() {
        this.authService.login();
    }

    register() {
        window.location.href = "http://localhost:5000/Account/Register"
    }
  }