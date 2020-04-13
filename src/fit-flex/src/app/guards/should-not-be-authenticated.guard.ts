import { Injectable } from '@angular/core';
import { CanActivate, Router, RouterStateSnapshot, UrlTree, ActivatedRouteSnapshot } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { Observable } from 'rxjs';

@Injectable()
export class ShouldNotBeAthenticatedGuard implements CanActivate {

    constructor(
        private authService: AuthService,
        private router: Router
    ) {}
    
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        if (this.authService.isUserLoggedIn) {
            return this.router.parseUrl('/fit');
        }
        return true;
    }

}