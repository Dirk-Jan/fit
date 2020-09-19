import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OefeningApi } from './apis/oefening.api';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { registerLocaleData } from '@angular/common';
import localeNl from '@angular/common/locales/nl';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { FitModule } from './modules/fit/fit.module';
import { LandingPageModule } from './modules/landing-page/landing-page.module';
import { ContentLayout } from './layouts/content-layout/content.layout';
import { EmptyLayout } from './layouts/empty-layout/empty.layout';
import { AuthModule } from './modules/auth/auth.module';
import { UnauthorizedPage } from './layouts/unauthorized/unauthorized.page';
import { ShouldNotBeAthenticatedGuard } from './guards/should-not-be-authenticated.guard';
import { RouterModule } from '@angular/router';
import { HasToBeAthenticatedGuard } from './guards/has-to-be-authenticated.guard';
import { WorkoutApi } from './apis/workout.api';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
registerLocaleData(localeNl, 'nl');

@NgModule({
  declarations: [
    AppComponent,
    ContentLayout,
    EmptyLayout,
    UnauthorizedPage
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FitModule,
    LandingPageModule,
    AuthModule,
    RouterModule,
    ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production })
  ],
  providers: [
    {provide: LOCALE_ID, useValue: 'nl' },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },
    ShouldNotBeAthenticatedGuard,
    HasToBeAthenticatedGuard,
    OefeningApi,
    WorkoutApi
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
