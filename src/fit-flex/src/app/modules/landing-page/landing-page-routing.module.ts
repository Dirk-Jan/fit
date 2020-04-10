import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPagePage } from './pages/landing-page/landing-page.page';

const routes: Routes = [
    {
      path: '',
      component: LandingPagePage
    }
  ];
  
  @NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
  export class LandingPageRoutingModule { }