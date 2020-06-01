import { Component, OnInit } from "@angular/core";
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';

@Component({
    templateUrl: './auth-callback.page.html',
    styleUrls: ['./auth-callback.page.css']
})
export class AuthCallbackPage implements OnInit {
    constructor(
        private authService: AuthService,
        private router: Router
        ) {}


    async ngOnInit() {
        console.log('completing login ....');
        await this.authService.completeLogin();
        this.router.navigateByUrl('/fit');
    }
}