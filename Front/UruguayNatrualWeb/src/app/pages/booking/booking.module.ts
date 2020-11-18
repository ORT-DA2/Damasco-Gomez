import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookingsTableComponent } from './bookings-table/bookings-table.component';
import { BookingDashboardComponent } from './booking-dashboard/booking-dashboard.component';
import { BookingEditorComponent } from './booking-editor/booking-editor.component';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
  imports: [
    CommonModule,
    BookingModule,
    ReactiveFormsModule,
    BrowserModule,
  ],
  declarations: [
    BookingsTableComponent,
    BookingDashboardComponent,
    BookingEditorComponent
  ],
  providers: [],
})
export class BookingModule { }
