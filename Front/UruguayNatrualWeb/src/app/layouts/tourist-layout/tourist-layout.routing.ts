import { Routes } from '@angular/router';
import { LoginComponent } from 'src/app/pages/login/login.component';
import { RegisterComponent } from 'src/app/pages/register/register.component';
import { HouseSearchComponent } from 'src/app/pages/search/house-search/house-search.component';
import { SearchDashboardComponent } from 'src/app/pages/search/search-dashboard/search-dashboard.component';
import { TableTouristPointsComponent } from 'src/app/pages/search/table-tourist-points/table-tourist-points.component';

export const TouristLayoutRoutes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'search', component: SearchDashboardComponent, },
  {
    path: 'search',
    children: [
      { path: ':name/:id', component: TableTouristPointsComponent },
      { path: 'tourist-point/:id', component: HouseSearchComponent },
    ]
  },
  {
    path: 'search',
    children: [
      { path: '/:name/:id', component: TableTouristPointsComponent },
      { path: 'tourist-point/:id', component: HouseSearchComponent },
    ]
  },

];
