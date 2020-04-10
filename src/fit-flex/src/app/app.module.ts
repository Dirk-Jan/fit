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
registerLocaleData(localeNl, 'nl');

@NgModule({
  declarations: [
    AppComponent,
    ContentLayout,
    EmptyLayout
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FitModule,
    LandingPageModule,
    AuthModule
  ],
  providers: [
    {provide: LOCALE_ID, useValue: 'nl' },
    OefeningApi,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
