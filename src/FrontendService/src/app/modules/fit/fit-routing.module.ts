import { Routes, RouterModule } from '@angular/router';
import { OefeningPage } from './pages/oefening/oefening.page';
import { NgModule } from '@angular/core';
import { OefeningFormComponent } from './components/oefening-form/oefening-form.component';
import { OefeningenOverzichtPage } from './pages/oefeningen-overzicht/oefeningen-overzicht.page';
import { AuthPolicies } from 'src/app/constants/auth-policies';
import { ClaimsAuthGuard } from 'src/app/guards/claims-auth.guard';
import { RouterPaths } from 'src/app/constants/router-paths';
import { WorkoutOverzichtPage } from './pages/workout-overzicht/workout-overzicht.page';
import { WorkoutPage } from './pages/workout/workout.page';
import { OefeningNieuwPage } from './pages/oefening-nieuw/oefening-nieuw.page';
import { OefeningBewerkenPage } from './pages/oefening-bewerken/oefening-bewerken.page';

const routes: Routes = [
    {
      path: `${RouterPaths.OefeningDetails}/:id`,
      // path: `fit/oefeningen/:id`,
      component: OefeningPage,
      pathMatch: 'full',
      canActivate: [ClaimsAuthGuard],
      data: { authPolicy: AuthPolicies.KanOefeningenZienPolicy }
    },
    {
      path: RouterPaths.OefeningenOverzicht,
      component: OefeningenOverzichtPage,
      pathMatch: 'full',
      canActivate: [ClaimsAuthGuard],
      data: { authPolicy: AuthPolicies.KanOefeningenZienPolicy }
    },
    {
      path: RouterPaths.NieuweOefening,
      component: OefeningNieuwPage,
      pathMatch: 'full',
      canActivate: [ClaimsAuthGuard],
      data: { authPolicy: AuthPolicies.KanOefeningenToevoegenPolicy }
    },
    {
      path: `${RouterPaths.OefeningBewerken}/:id`,
      component: OefeningBewerkenPage,
      pathMatch: 'full',
      canActivate: [ClaimsAuthGuard],
      data: { authPolicy: AuthPolicies.KanOefeningenAanpassenPolicy }
    },
    {
      path: '',
      component: OefeningenOverzichtPage,
      canActivate: [ClaimsAuthGuard],
      data: { authPolicy: AuthPolicies.KanOefeningenZienPolicy }
    },
    {
      path: `${RouterPaths.WorkoutDetails}/:workoutDag`,
      component: WorkoutPage,
      pathMatch: 'full',
      canActivate: [ClaimsAuthGuard],
      data: { authPolicy: AuthPolicies.KanOefeningenZienPolicy }
    },
    {
      path: RouterPaths.WorkoutOverzicht,
      component: WorkoutOverzichtPage,
      pathMatch: 'full',
      canActivate: [ClaimsAuthGuard],
      data: { authPolicy: AuthPolicies.KanOefeningenZienPolicy }
    },
    // Fallback when no prior routes is matched
    { 
      path: '**', 
      redirectTo: '', 
      pathMatch: 'full' 
    }
  ];
  
  @NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
  export class FitRoutingModule { }