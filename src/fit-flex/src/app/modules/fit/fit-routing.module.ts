import { Routes, RouterModule } from '@angular/router';
import { OefeningPage } from './pages/oefening/oefening.page';
import { NgModule } from '@angular/core';
import { OefeningReadGuard } from 'src/app/guards/oefening-read.guard';
import { OefeningAddGuard } from 'src/app/guards/oefening-add.guard';
import { OefeningFormComponent } from './components/oefening-form/oefening-form.component';
import { OefeningenOverzichtPage } from './pages/oefeningen-overzicht/oefeningen-overzicht.page';

const routes: Routes = [
    {
      path: 'oefeningen/:id',
      component: OefeningPage,
      pathMatch: 'full',
    //   canActivate: [OefeningReadGuard]
    },
    {
      path: 'oefeningen',
      component: OefeningenOverzichtPage,
    //   canActivate: [OefeningReadGuard]
    },
    {
      path: 'nieuwe-oefening',
      component: OefeningFormComponent,
    //   canActivate: [OefeningAddGuard]
    },
    {
      path: '',
      component: OefeningenOverzichtPage
    }
  ];
  
  @NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
  export class FitRoutingModule { }