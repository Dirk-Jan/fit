import { LandingPagePage } from './pages/landing-page/landing-page.page';
import { NgModule } from '@angular/core';
import { LandingPageRoutingModule } from './landing-page-routing.module';
import { CommonModule } from '@angular/common';

@NgModule({
    declarations: [
      LandingPagePage
    ],
    imports: [
      CommonModule,
      LandingPageRoutingModule
    ],
    providers: [
    ]
  })
  export class LandingPageModule {}