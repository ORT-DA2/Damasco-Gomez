import { Component, OnInit } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { BookingBasicInfo } from 'src/app/models/booking/booking-base-info';
import { ReviewBasicInfo } from 'src/app/models/reviews/review-base-info';
import { BookingService } from 'src/app/services/bookings/booking.service';
import { ReviewService } from 'src/app/services/reviews/review.service';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.css']
})
export class ReviewComponent implements OnInit {
  private bookings: BookingBasicInfo[] = [];
  private code: string = '';
  showInputsReview = false;
  errorMessageCode = '';
  review: ReviewBasicInfo = {} as ReviewBasicInfo;
  disableSend: boolean = false;
  errorMessageEndpoint: string = '';
  successMessage: string = '';

  constructor(private bookingService: BookingService, private reviewService: ReviewService) { }

  ngOnInit(): void {
    this.bookingService.getAll().subscribe(
      bookingResponse =>
        this.getAll(bookingResponse), (error: string) => this.showError(error)
    );
  }

  private getAll(bookingResponse: BookingBasicInfo[]){
    this.bookings = bookingResponse;
  }

  private showError(message){
    this.errorMessageEndpoint  = message;
  }

  checkBookingCode(){
    var bookingWithCode = this.bookings.filter(x => x.code == this.code);
    if (bookingWithCode.length != 0){
      this.showInputsReview = true;
      this.errorMessageCode = '';
      this.review.houseId = bookingWithCode[0].houseId;
    }
    else {
      this.errorMessageCode = 'Code was not found in the list, check it please';
    }
  }

  send(){
    this.reviewService.add(this.review).subscribe(
      response => {
        this.disableSend = true;
        this.errorMessageEndpoint = '';
        this.successMessage = 'Done!'
      },
      catchError => {
        this.errorMessageEndpoint = catchError + ', fix it and try again';
      }
    );
  }
}
