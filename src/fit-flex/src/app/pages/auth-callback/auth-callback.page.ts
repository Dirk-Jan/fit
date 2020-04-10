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

    text: string = 'HALLOO';
    async ngOnInit() {
        await this.authService.completeLogin();
        this.text = 'INGELOGD';
        console.log('nieuwe text = ', this.text);
        this.router.navigateByUrl('');
    }
}