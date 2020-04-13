import { Injectable } from "@angular/core";
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { Observable } from 'rxjs';
import { AuthPolicyValidator } from '../auth/auth-policy-validator';
import { AuthPolicy } from '../auth/auth-policy';

@Injectable()
export class ClaimsAuthGuard implements CanActivate {

    // protected authPolicy: AuthPolicy;

    constructor(
        private authService: AuthService,
        private authPolicyValidator: AuthPolicyValidator,
        private router: Router
        ) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
        // if (!this.authService.isUserLoggedIn) {
        //     this.authService.login();
        //     return;
        // }

        // for (let i=0; i<this.requiredClaims.length; i++) {
        //     if (!this.authService.hasAuthClaim(this.requiredClaims[i])) {
        //         return false;   // Of laat accesd denied ofzo zien
        //     }
        // }

        // return true;
        let authPolicy = route.data.authPolicy as AuthPolicy;
        let allowed = this.authPolicyValidator.isAllowed(authPolicy);

        if (!allowed) {
            this.router.navigateByUrl('/unauthorized');
            return false;
        }

        return true;
    }
}