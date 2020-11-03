import { Component, OnInit } from '@angular/core';
import { BookingBasicInfo } from 'src/app/models/booking/booking-base-info';
import { BookingService } from 'src/app/services/bookings/booking.service';

@Component({
  selector: 'app-bookings-table',
  templateUrl: './bookings-table.component.html',
  styleUrls: ['./bookings-table.component.css']
})
export class BookingsTableComponent implements OnInit {
  public bookings: BookingBasicInfo[] = [];
  public id: Number = 0;
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

  private delete(event) {
    this.id = event.id;
    this.bookingService.delete(this.id).subscribe(
      bookingResponse =>
        this.delete(bookingResponse), (error: string) => this.showError(error)
    );
    this.bookings = this.bookings.filter(item => item.id != this.id);
  }
}
