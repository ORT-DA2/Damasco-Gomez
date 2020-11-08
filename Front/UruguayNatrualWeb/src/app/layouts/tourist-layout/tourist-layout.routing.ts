import { Routes } from '@angular/router';
import { LoginComponent } from 'src/app/pages/login/login.component';
import { RegisterComponent } from 'src/app/pages/register/register.component';
import { SearchDashboardComponent } from 'src/app/pages/search/search-dashboard/search-dashboard.component';

export const TouristLayoutRoutes: Routes = [
  { path: 'login',          component: LoginComponent },
  { path: 'register',       component: RegisterComponent },
  { path: 'search',       component: SearchDashboardComponent },
];
