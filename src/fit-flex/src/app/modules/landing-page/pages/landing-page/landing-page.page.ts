import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { environment } from 'src/environments/environment';

@Component({
    selector: 'app-landing-page',
    templateUrl: './landing-page.page.html',
    styleUrls: ['./landing-page-dark.page.css']
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
        window.location.href = `${environment.authUrl}/Account/Register`
    }
  }