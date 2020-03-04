import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OefeningComponent } from './components/oefening/oefening.component';
import { OefeningPrestatieComponent } from './components/oefening-prestatie/oefening-prestatie.component';
import { ReadMoreReadLessComponent } from './components/read-more-read-less/read-more-read-less.component';
import { OefeningFormComponent } from './components/oefening-form/oefening-form.component';
import { PrestatieFormComponent } from './components/prestatie-form/prestatie-form.component';
import { VorigePrestatiesComponent } from './components/vorige-prestaties/vorige-prestaties.component';
import { OefeningenOverzichtPage } from './pages/oefeningen-overzicht/oefeningen-overzicht.page';

@NgModule({
  declarations: [
    AppComponent,
    OefeningComponent,
    OefeningPrestatieComponent,
    ReadMoreReadLessComponent,
    OefeningFormComponent,
    PrestatieFormComponent,
    VorigePrestatiesComponent,
    OefeningenOverzichtPage
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
