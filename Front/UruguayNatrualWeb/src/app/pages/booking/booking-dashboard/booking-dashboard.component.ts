import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookingService } from 'src/app/services/bookings/booking.service';

@Component({
  selector: 'app-booking-dashboard',
  templateUrl: './booking-dashboard.component.html',
  styleUrls: ['./booking-dashboard.component.css']
})
export class BookingDashboardComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private bookingService: BookingService,) { }

  ngOnInit(): void {
  }


}
