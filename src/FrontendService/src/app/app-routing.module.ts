import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ContentLayout } from './layouts/content-layout/content.layout';
import { EmptyLayout } from './layouts/empty-layout/empty.layout';
import { UnauthorizedPage } from './layouts/unauthorized/unauthorized.page';
import { ShouldNotBeAthenticatedGuard } from './guards/should-not-be-authenticated.guard';
import { HasToBeAthenticatedGuard } from './guards/has-to-be-authenticated.guard';
import { RouterPaths } from './constants/router-paths';
import { RouterModulePaths } from './constants/router-module-paths';


const routes: Routes = [
  {
    path: RouterModulePaths.FitModulePrefix,
    component: ContentLayout,
    canActivate: [HasToBeAthenticatedGuard],
    children: [
      { path: '', loadChildren: () => import('./modules/fit/fit.module').then(m => m.FitModule) }
    ]
  },
  {
    path: RouterModulePaths.AuthModulePrefix,
    component: EmptyLayout,
    children: [
      { path: '', loadChildren: () => import('./modules/auth/auth.module').then(m => m.AuthModule) }
    ]
  },
  {
    path: RouterPaths.Unauthorized,
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
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
