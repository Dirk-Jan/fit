import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OefeningComponent } from './components/oefening/oefening.component';
import { OefeningPrestatieComponent } from './components/oefening-prestatie/oefening-prestatie.component';
import { ReadMoreReadLessComponent } from './components/read-more-read-less/read-more-read-less.component';

@NgModule({
  declarations: [
    AppComponent,
    OefeningComponent,
    OefeningPrestatieComponent,
    ReadMoreReadLessComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
