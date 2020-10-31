import { Component, OnInit } from '@angular/core';
import { BookingDetailInfo } from 'src/app/models/booking/booking-detail-info';
import { BookingService } from 'src/app/services/bookings/booking.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-booking-editor',
  templateUrl: './booking-editor.component.html',
  styleUrls: ['./booking-editor.component.css']
})
export class BookingEditorComponent implements OnInit {
  public booking: BookingDetailInfo = null;
  public houses: HouseBasicInfo[] = [];
  public bookingId: number = 0;
  constructor(private route: ActivatedRoute, private bookingService: BookingService) { }


  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.bookingId = Number(id);
    this.bookingService.getBy(this.bookingId).subscribe(
      bookingResponse =>
        this.getBy(bookingResponse), (error: string) => this.showError(error));
  }

  private getBy(bookingResponse: BookingDetailInfo){
    this.booking = bookingResponse;
  }

  private showError(message: string){
    console.log(message);
  }

}
