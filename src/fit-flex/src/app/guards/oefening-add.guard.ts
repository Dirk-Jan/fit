import { Injectable } from "@angular/core";
import { ClaimsAuthGuard } from './claims-auth.guard';
import { AuthService } from '../services/auth.service';
import { AuthClaims } from '../constants/auth-claims';

@Injectable()
export class OefeningAddGuard extends ClaimsAuthGuard {

    constructor(authService: AuthService) {
        super(authService);
        this.requiredClaims = [
            AuthClaims.FitFlexOefeningAdd
        ];
    }
}