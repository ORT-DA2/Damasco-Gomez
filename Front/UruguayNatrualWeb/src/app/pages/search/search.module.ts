import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TableCategoriesComponent } from './table-categories/table-categories.component';
import { TableRegionsComponent } from './table-regions/table-regions.component';
import { SearchDashboardComponent } from './search-dashboard/search-dashboard.component';
import { TableTouristPointsComponent } from './table-tourist-points/table-tourist-points.component';
import { HouseSearchComponent } from './house-search/house-search.component';



@NgModule({
  imports: [
    CommonModule,
    SearchModule,
  ],
  declarations: [
    TableCategoriesComponent,
    TableRegionsComponent,
    SearchDashboardComponent,
    TableTouristPointsComponent,
    HouseSearchComponent,
  ],
  providers: [],
  exports: []
})
export class SearchModule { }
