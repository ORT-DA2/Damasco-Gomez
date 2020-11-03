import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TouristPointEditorComponent } from './tourist-point-editor/tourist-point-editor.component';
import { TouristPointsTableComponent } from './tourist-points-table/tourist-points-table.component';
import { TouristPointDashboardComponent } from './tourist-point-dashboard/tourist-point-dashboard.component';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  imports: [
    CommonModule,
    TouristPointModule,
    BrowserModule,
    ReactiveFormsModule,
  ],
  declarations: [
    TouristPointEditorComponent,
    TouristPointsTableComponent,
    TouristPointDashboardComponent
  ],
  providers: [],
})
export class TouristPointModule { }
