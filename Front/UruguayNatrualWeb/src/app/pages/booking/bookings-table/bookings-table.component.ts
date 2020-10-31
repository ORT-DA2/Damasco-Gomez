import { Component, OnInit } from '@angular/core';
import { Console } from 'console';
import { BookingBasicInfo } from 'src/app/models/booking/booking-base-info';
import { BookingDetailInfo } from 'src/app/models/booking/booking-detail-info';
import { BookingService } from 'src/app/services/bookings/booking.service';

@Component({
  selector: 'app-bookings-table',
  templateUrl: './bookings-table.component.html',
  styleUrls: ['./bookings-table.component.css']
})
export class BookingsTableComponent implements OnInit {
  public bookings: BookingBasicInfo[] = [];
  constructor(private bookingService: BookingService) { }

  ngOnInit(): void {
    this.bookingService.getAll().subscribe(
      bookingResponse =>
        this.getAll(bookingResponse), (error: string) => this.showError(error));
  }

  private getAll(bookingResponse: BookingBasicInfo[]){
    this.bookings = bookingResponse;
  }

  private showError(message: string){
    console.log(message);
  }

  private get(event) {
    console.log(event);
  }

  private delete(event) {
    console.log(event);
  }
}
