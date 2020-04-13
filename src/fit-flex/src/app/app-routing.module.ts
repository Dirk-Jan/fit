import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ContentLayout } from './layouts/content-layout/content.layout';
import { EmptyLayout } from './layouts/empty-layout/empty.layout';
import { UnauthorizedPage } from './layouts/unauthorized/unauthorized.page';
import { ShouldNotBeAthenticatedGuard } from './guards/should-not-be-authenticated.guard';
import { HasToBeAthenticatedGuard } from './guards/has-to-be-authenticated.guard';


const routes: Routes = [
  {
    path: 'fit',
    component: ContentLayout,
    canActivate: [HasToBeAthenticatedGuard],
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
    path: 'unauthorized',
    component: UnauthorizedPage
  },
  {
    path: '',
    component: EmptyLayout,
    canActivate: [ShouldNotBeAthenticatedGuard],
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
