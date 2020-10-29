import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookingsComponent } from './bookings/bookings.component';

@NgModule({
  imports: [
    CommonModule,
    BookingModule,
  ],
  declarations: [
    BookingsComponent
  ],
  providers: [],
})
export class BookingModule { }
