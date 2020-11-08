import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TableCategoriesComponent } from './table-categories/table-categories.component';
import { TableRegionsComponent } from './table-regions/table-regions.component';
import { SearchDashboardComponent } from './search-dashboard/search-dashboard.component';



@NgModule({
  imports: [
    CommonModule,
    SearchModule
  ],
  declarations: [
    TableCategoriesComponent,
    TableRegionsComponent,
    SearchDashboardComponent,
  ],
  providers: [],
  exports: []
})
export class SearchModule { }
