import { NgModule } from "@angular/core";
import { FitRoutingModule } from './fit-routing.module';
import { OefeningPage } from './pages/oefening/oefening.page';
import { OefeningPrestatieComponent } from './components/oefening-prestatie/oefening-prestatie.component';
import { ReadMoreReadLessComponent } from './components/read-more-read-less/read-more-read-less.component';
import { OefeningFormComponent } from './components/oefening-form/oefening-form.component';
import { PrestatieFormComponent } from './components/prestatie-form/prestatie-form.component';
import { VorigePrestatiesComponent } from './components/vorige-prestaties/vorige-prestaties.component';
import { OefeningenOverzichtPage } from './pages/oefeningen-overzicht/oefeningen-overzicht.page';
import { PrestatieDagComponent } from './components/prestatie-dag/prestatie-dag.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AuthPolicyValidator } from 'src/app/auth/auth-policy-validator';
import { CommonModule } from '@angular/common';
import { ClaimsAuthGuard } from 'src/app/guards/claims-auth.guard';
import { WorkoutItemComponent } from './components/workout-item/workout-item.component';
import { WorkoutOverzichtPage } from './pages/workout-overzicht/workout-overzicht.page';
import { OefeningApi } from 'src/app/apis/oefening.api';
import { WorkoutApi } from 'src/app/apis/workout.api';
import { WorkoutPage } from './pages/workout/workout.page';

@NgModule({
  declarations: [
    OefeningPage,
    OefeningPrestatieComponent,
    ReadMoreReadLessComponent,
    OefeningFormComponent,
    PrestatieFormComponent,
    VorigePrestatiesComponent,
    OefeningenOverzichtPage,
    PrestatieDagComponent,
    WorkoutItemComponent,
    WorkoutOverzichtPage,
    WorkoutPage
  ],
  imports: [
    CommonModule,
    FitRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    ClaimsAuthGuard,
    AuthPolicyValidator,
    // OefeningApi,
    // WorkoutApi
  ]
})
export class FitModule {}