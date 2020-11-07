import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { LoginComponent } from 'src/app/pages/login/login.component';
import { RegisterComponent } from 'src/app/pages/register/register.component';
import { TouristLayoutRoutes } from './tourist-layout.routing';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(TouristLayoutRoutes),
    FormsModule
  ],
  declarations: [
    LoginComponent,
    RegisterComponent
  ]
})
export class TouristLayoutModule { }
