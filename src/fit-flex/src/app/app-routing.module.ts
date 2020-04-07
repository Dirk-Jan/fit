import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OefeningenOverzichtPage } from './pages/oefeningen-overzicht/oefeningen-overzicht.page';
import { OefeningFormComponent } from './components/oefening-form/oefening-form.component';
import { OefeningPage } from './pages/oefening/oefening.page';
import { AuthCallbackPage } from './pages/auth-callback/auth-callback.page';
import { OefeningReadGuard } from './guards/oefening-read.guard';
import { OefeningAddGuard } from './guards/oefening-add.guard';


const routes: Routes = [
  {
    path: 'oefeningen/:id',
    component: OefeningPage,
    pathMatch: 'full',
    canActivate: [OefeningReadGuard]
  },
  {
    path: 'oefeningen',
    component: OefeningenOverzichtPage,
    canActivate: [OefeningReadGuard]
  },
  {
    path: 'nieuwe-oefening',
    component: OefeningFormComponent,
    canActivate: [OefeningAddGuard]
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
