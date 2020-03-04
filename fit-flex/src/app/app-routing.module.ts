import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OefeningenOverzichtPage } from './pages/oefeningen-overzicht/oefeningen-overzicht.page';


const routes: Routes = [
  {
    path: 'oef',
    component: OefeningenOverzichtPage
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
