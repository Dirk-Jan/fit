import { Injectable } from "@angular/core";
import { UserManager, User } from 'oidc-client';
import { resolve } from 'dns';

@Injectable({ providedIn: 'root' })
export class AuthService {
    private settings = {
        authority: 'http://localhost:5000',
        client_id: 'fit.frontend',
        redirect_uri: 'http://localhost:4200/auth-callback',
        response_type: 'id_token token',
        scope: 'openid profile fit.bff'
    };
    user: User;
    manager: UserManager;

    constructor() {
        this.manager = new UserManager(this.settings);
    }

    login() {
        this.manager.signinRedirect();
    }

    logout() {
        this.manager.signoutRedirect();
    }

    get name() : string {
        return this.user.profile.name;
    }

    get isUserLoggedIn() : boolean {
        return this.user !== undefined && this.user !== null && !this.user.expired;
    }

    // waitForUserToBeAuthenticated() {
    //     return new Promise(resolve => {
    //         setTimeout(() => {

    //         })
    //     });
    // }

    // Eeen event zou beter zijn
    // maar moet misschien sowieso even kijken hoe ik de token ga opslaan, omdat je die anders kwijt bent met een refresh

    get token() {
        if (!this.isUserLoggedIn)
            return '';
            // this.login();
        return `${this.user.token_type} ${this.user.access_token}`;
    }

    async completeLogin() {
        this.user = await this.manager.signinRedirectCallback();
        console.log('[Auth] user: ', this.user);
    }

    hasAuthClaim(claim: string) : boolean {
        let result = atob(this.token.split('.')[1])

        let tokenKeyValuePair = `"${claim}":"true"`;
        return result.includes(tokenKeyValuePair);
    }
}