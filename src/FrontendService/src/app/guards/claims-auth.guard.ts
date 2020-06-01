import { Injectable } from "@angular/core";
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthPolicyValidator } from '../auth/auth-policy-validator';
import { AuthPolicy } from '../auth/auth-policy';
import { InternalEndpoints } from '../constants/internal-endpoints';

@Injectable()
export class ClaimsAuthGuard implements CanActivate {

    constructor(
        private authPolicyValidator: AuthPolicyValidator,
        private router: Router
        ) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
        let authPolicy = route.data.authPolicy as AuthPolicy;
        let allowed = this.authPolicyValidator.isAllowed(authPolicy);
console.log('allowed ', allowed);
        if (!allowed) {
            this.router.navigateByUrl(InternalEndpoints.Unauthorized);
            return false;
        }

        return true;
    }
}