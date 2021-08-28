import { LandingPagePage } from './pages/landing-page/landing-page.page';
import { NgModule } from '@angular/core';
import { LandingPageRoutingModule } from './landing-page-routing.module';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';

@NgModule({
    declarations: [
      LandingPagePage
    ],
    imports: [
      CommonModule,
      LandingPageRoutingModule,
      MatCardModule,
      MatButtonModule,
    ],
    providers: [
    ]
  })
  export class LandingPageModule {}