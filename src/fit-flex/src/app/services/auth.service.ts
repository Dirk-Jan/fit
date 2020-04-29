import { Injectable } from "@angular/core";
import { UserManager, User } from 'oidc-client';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class AuthService {
    private settings = {
        authority: environment.authUrl,
        client_id: 'fit.frontend',
        redirect_uri: environment.authCallbackUrl,
        response_type: 'id_token token',
        scope: 'openid profile fit.bff'
    };
    user: User;
    manager: UserManager;

    constructor() {
        this.manager = new UserManager(this.settings);
        let userInStorage = localStorage.getItem('authenticatedUser');
        if (userInStorage) {
            this.user = User.fromStorageString(userInStorage);
        }
    }

    login() {
        this.manager.signinRedirect();
    }

    async logout() {
        await this.manager.signoutRedirect();
        console.log('uitgelogd...');
        this.user = undefined;  // Hoeft misschien niet eens...
        localStorage.removeItem('authenticatedUser');
    }

    get name() : string {
        return this.user.profile.name;
    }

    get isUserLoggedIn() : boolean {
        return this.user !== undefined && this.user !== null && !this.user.expired;
    }

    get token() {
        if (!this.isUserLoggedIn)
            return '';
            // this.login();
        return `${this.user.token_type} ${this.user.access_token}`;
    }

    async completeLogin() {
        console.log('hi starting complete login...');
        this.user = await this.manager.signinRedirectCallback();
        console.log('[Auth] user: ', this.user);

        localStorage.setItem('authenticatedUser', this.user.toStorageString());
        console.log('user saved to localstorage');
    }

    hasAuthClaim(claim: string) : boolean {
        let result = atob(this.token.split('.')[1])

        let tokenKeyValuePair = `"${claim}":"true"`;
        return result.includes(tokenKeyValuePair);
    }
}