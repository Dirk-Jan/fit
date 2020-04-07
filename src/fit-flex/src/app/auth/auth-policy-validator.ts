import { AuthService } from '../services/auth.service';
import { AuthPolicy } from './auth-policy';
import { Injectable } from '@angular/core';

@Injectable()
export class AuthPolicyValidator {

    constructor(private authService: AuthService) { }
    
    isAllowed(authPolicy: AuthPolicy): boolean {
        console.log('policy: ', authPolicy);

        if (!this.authService.isUserLoggedIn) {
            return false;
        }

        for (let i=0; i<authPolicy.requiredClaims.length; i++) {
            if (!this.authService.hasAuthClaim(authPolicy.requiredClaims[i])) {
                return false;
            }
        }

        return true;
    }
}