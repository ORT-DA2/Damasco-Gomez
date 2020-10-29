import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { BookingBasicInfo } from 'src/app/models/booking/booking-base-info';
import { BookingDetailInfo } from 'src/app/models/booking/booking-detail-info';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  private uri = environment.baseURL+"bookings";
  private id = 1;
  constructor(private http: HttpClient) { }
  getAll():Observable<BookingBasicInfo[]>{
    return this.http.get<BookingBasicInfo[]>(this.uri)
      .pipe(catchError(this.handleError));
  }
  getBy(id):Observable<BookingDetailInfo>{
    return this.http.get<BookingDetailInfo>(this.uri + "/" + id)
        .pipe(catchError(this.handleError));
  }
  private handleError(error: HttpErrorResponse){
    let message: string;
    if (error.error instanceof ErrorEvent) {
      message = "Error: do it again";
    } else{
      if(error.status == 0){
        message = "The server is shutdown";
      }else{
        message = error.error.message;
      }
    }
    return throwError(message);
  }
}
