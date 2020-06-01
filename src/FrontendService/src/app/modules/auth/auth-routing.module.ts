import { Routes, RouterModule } from '@angular/router';
import { AuthCallbackPage } from './pages/auth-callback/auth-callback.page';
import { NgModule } from '@angular/core';

const routes: Routes = [
    {
      path: '',
      component: AuthCallbackPage
    }
  ];
  
  @NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
  export class AuthRoutingModule { }