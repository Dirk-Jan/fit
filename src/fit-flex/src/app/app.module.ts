import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OefeningPrestatieComponent } from './components/oefening-prestatie/oefening-prestatie.component';
import { ReadMoreReadLessComponent } from './components/read-more-read-less/read-more-read-less.component';
import { OefeningFormComponent } from './components/oefening-form/oefening-form.component';
import { PrestatieFormComponent } from './components/prestatie-form/prestatie-form.component';
import { VorigePrestatiesComponent } from './components/vorige-prestaties/vorige-prestaties.component';
import { OefeningenOverzichtPage } from './pages/oefeningen-overzicht/oefeningen-overzicht.page';
import { OefeningApi } from './apis/oefening.api';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { OefeningPage } from './pages/oefening/oefening.page';
import { PrestatieDagComponent } from './components/prestatie-dag/prestatie-dag.component';

import { registerLocaleData, CommonModule } from '@angular/common';
import localeNl from '@angular/common/locales/nl';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { AuthCallbackPage } from './pages/auth-callback/auth-callback.page';
import { OefeningReadGuard } from './guards/oefening-read.guard';
import { OefeningAddGuard } from './guards/oefening-add.guard';
import { AuthPolicyValidator } from './auth/auth-policy-validator';
registerLocaleData(localeNl, 'nl');

@NgModule({
  declarations: [
    AppComponent,
    AuthCallbackPage,
    OefeningPage,
    OefeningPrestatieComponent,
    ReadMoreReadLessComponent,
    OefeningFormComponent,
    PrestatieFormComponent,
    VorigePrestatiesComponent,
    OefeningenOverzichtPage,
    PrestatieDagComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    {provide: LOCALE_ID, useValue: 'nl' },
    OefeningApi,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },
    OefeningReadGuard,
    OefeningAddGuard,
    AuthPolicyValidator
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
