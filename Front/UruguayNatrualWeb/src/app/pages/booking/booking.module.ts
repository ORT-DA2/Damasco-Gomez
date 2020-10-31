import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookingsTableComponent } from './bookings-table/bookings-table.component';

@NgModule({
  imports: [
    CommonModule,
    BookingModule,
  ],
  declarations: [
    BookingsTableComponent
  ],
  providers: [],
})
export class BookingModule { }
