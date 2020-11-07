import { Routes } from '@angular/router';
import { LoginComponent } from 'src/app/pages/login/login.component';
import { RegisterForgotComponent } from 'src/app/pages/register-forgot/register-forgot.component';
import { RegisterComponent } from 'src/app/pages/register/register.component';

export const TouristLayoutRoutes: Routes = [
  { path: 'login',          component: LoginComponent },
  { path: 'register',       component: RegisterComponent },
  { path: 'register-forgot',       component: RegisterForgotComponent }
];
