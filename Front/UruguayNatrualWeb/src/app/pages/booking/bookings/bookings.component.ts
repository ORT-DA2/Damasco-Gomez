import { Component, OnInit } from '@angular/core';
import { BookingBasicInfo } from 'src/app/models/booking/booking-base-info';
import { BookingDetailInfo } from 'src/app/models/booking/booking-detail-info';
import { BookingService } from 'src/app/services/bookings/booking.service';

@Component({
  selector: 'app-bookings',
  templateUrl: './bookings.component.html',
  styleUrls: ['./bookings.component.css']
})
export class BookingsComponent implements OnInit {
  public bookings: BookingBasicInfo[] = [];
  public booking: BookingDetailInfo;
  public id: number = 0;
  constructor(private bookingService: BookingService) { }

  ngOnInit(): void {
    this.bookingService.getAll().subscribe(
      bookingResponse =>
        this.getAll(bookingResponse), (error: string) => this.showError(error));
    this.bookingService.getBy(this.id).subscribe(
      bookingResponse =>
        this.getBy(bookingResponse), (error: string) => this.showError(error));
  }

  private getAll(bookingResponse: BookingBasicInfo[]){
    this.bookings = bookingResponse;
  }
  private getBy(bookingResponse: BookingDetailInfo){
    this.booking = bookingResponse;
  }

  private showError(message: string){
    console.log(message);
  }
}
