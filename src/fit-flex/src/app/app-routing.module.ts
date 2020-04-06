import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OefeningenOverzichtPage } from './pages/oefeningen-overzicht/oefeningen-overzicht.page';
import { OefeningFormComponent } from './components/oefening-form/oefening-form.component';
import { OefeningPage } from './pages/oefening/oefening.page';
import { AuthCallbackPage } from './pages/auth-callback/auth-callback.page';


const routes: Routes = [
  {
    path: 'oefeningen/:id',
    component: OefeningPage,
    pathMatch: 'full'
  },
  {
    path: 'oefeningen',
    component: OefeningenOverzichtPage
  },
  {
    path: 'nieuwe-oefening',
    component: OefeningFormComponent
  },
  {
    path: 'auth-callback',
    component: AuthCallbackPage
  },
  {
    path: '',
    component: OefeningenOverzichtPage
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
