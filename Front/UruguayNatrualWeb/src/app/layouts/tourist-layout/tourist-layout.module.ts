import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MaterialModule } from 'src/app/material/material.module';
import { LoginComponent } from 'src/app/pages/login/login.component';
import { RegisterComponent } from 'src/app/pages/register/register.component';
import { HouseSearchComponent } from 'src/app/pages/search/house-search/house-search.component';
import { SearchDashboardComponent } from 'src/app/pages/search/search-dashboard/search-dashboard.component';
import { TableCategoriesComponent } from 'src/app/pages/search/table-categories/table-categories.component';
import { TableRegionsComponent } from 'src/app/pages/search/table-regions/table-regions.component';
import { TableTouristPointsComponent } from 'src/app/pages/search/table-tourist-points/table-tourist-points.component';
import { TouristLayoutRoutes } from './tourist-layout.routing';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(TouristLayoutRoutes),
    FormsModule,
    MaterialModule
  ],
  declarations: [
    LoginComponent,
    RegisterComponent,
    SearchDashboardComponent,
    TableCategoriesComponent,
    TableRegionsComponent,
    TableTouristPointsComponent,
    HouseSearchComponent,
  ]
})
export class TouristLayoutModule { }
