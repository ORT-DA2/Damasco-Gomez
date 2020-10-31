import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookingsTableComponent } from './bookings-table/bookings-table.component';
import { BookingDashboardComponent } from './booking-dashboard/booking-dashboard.component';

@NgModule({
  imports: [
    CommonModule,
    BookingModule,
  ],
  declarations: [
    BookingsTableComponent,
    BookingDashboardComponent
  ],
  providers: [],
})
export class BookingModule { }
