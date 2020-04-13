import { Routes, RouterModule } from '@angular/router';
import { OefeningPage } from './pages/oefening/oefening.page';
import { NgModule } from '@angular/core';
import { OefeningFormComponent } from './components/oefening-form/oefening-form.component';
import { OefeningenOverzichtPage } from './pages/oefeningen-overzicht/oefeningen-overzicht.page';
import { AuthPolicies } from 'src/app/constants/auth-policies';
import { ClaimsAuthGuard } from 'src/app/guards/claims-auth.guard';
import { Endpoints } from 'src/app/constants/endpoints';

const routes: Routes = [
    {
      path: Endpoints.OefeningDetails + '/:id',
      component: OefeningPage,
      pathMatch: 'full',
      canActivate: [ClaimsAuthGuard],
      data: { authPolicy: AuthPolicies.KanOefeningenZienPolicy }
    },
    {
      path: Endpoints.OefeningenOverzicht,
      component: OefeningenOverzichtPage,
      canActivate: [ClaimsAuthGuard],
      data: { authPolicy: AuthPolicies.KanOefeningenZienPolicy }
    },
    {
      path: 'nieuwe-oefening',
      component: OefeningFormComponent,
      canActivate: [ClaimsAuthGuard],
      data: { authPolicy: AuthPolicies.KanOefeningenToevoegenPolicy }
    },
    {
      path: '',
      component: OefeningenOverzichtPage,
      canActivate: [ClaimsAuthGuard],
      data: { authPolicy: AuthPolicies.KanOefeningenZienPolicy }
    }
  ];
  
  @NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
  export class FitRoutingModule { }