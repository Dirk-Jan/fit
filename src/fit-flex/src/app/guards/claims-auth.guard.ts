import { Injectable } from "@angular/core";
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { Observable } from 'rxjs';

export abstract class ClaimsAuthGuard implements CanActivate {

    protected requiredClaims: string[] = [];

    constructor(private authService: AuthService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
        if (!this.authService.isUserLoggedIn) {
            this.authService.login();
            return;
        }

        for (let i=0; i<this.requiredClaims.length; i++) {
            if (!this.authService.hasAuthClaim(this.requiredClaims[i])) {
                return false;   // Of laat accesd denied ofzo zien
            }
        }

        return true;
    }
}