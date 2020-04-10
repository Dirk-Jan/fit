import { NgModule } from "@angular/core";
import { AuthCallbackPage } from './pages/auth-callback/auth-callback.page';
import { CommonModule } from '@angular/common';
import { AuthRoutingModule } from './auth-routing.module';

@NgModule({
    declarations: [
        AuthCallbackPage
    ],
    imports: [
        CommonModule,
        AuthRoutingModule
    ]
})
export class AuthModule {}