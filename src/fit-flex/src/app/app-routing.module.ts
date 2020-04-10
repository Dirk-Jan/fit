import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ContentLayout } from './layouts/content-layout/content.layout';
import { EmptyLayout } from './layouts/empty-layout/empty.layout';


const routes: Routes = [
  {
    path: 'fit',
    component: ContentLayout,
    children: [
      { path: '', loadChildren: () => import('./modules/fit/fit.module').then(m => m.FitModule) }
    ]
  },
  {
    path: 'auth-callback',
    component: EmptyLayout,
    children: [
      { path: '', loadChildren: () => import('./modules/auth/auth.module').then(m => m.AuthModule) }
    ]
  },
  {
    path: '',
    component: EmptyLayout,
    children: [
      { path: '', loadChildren: () => import('./modules/landing-page/landing-page.module').then(m => m.LandingPageModule) }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
