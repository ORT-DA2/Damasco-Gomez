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

  private id = 1;
  private uri;

  constructor(private http: HttpClient) {
    this.uri = environment.baseURL+"bookings";
  }

  getAll():Observable<BookingBasicInfo[]>{
    return this.http.get<BookingBasicInfo[]>(this.uri)
      .pipe(catchError(this.handleError));
  }

  getBy(id):Observable<BookingDetailInfo>{
    var httpRequest =
    this.http.get<BookingDetailInfo>(this.uri + "/" + id)
        .pipe(catchError(this.handleError));
    return httpRequest;
  }

  post(body):Observable<any>{
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    let options = { headers: headers };
    var httpRequest = this.http.post<any>(this.uri, body, options)
      .pipe(catchError(this.handleError));
    return httpRequest;
  }


  delete(id):Observable<any>{
    const headers = new HttpHeaders({
      'Authorization': environment.token,
      'Content-Type':'application/json'
    });
    let options = { headers: headers };
    var httpRequest = this.http.delete<any>(this.uri + "/" + id, options)
      .pipe(catchError(this.handleError));
    return httpRequest;
  }

  update(id, body):Observable<any>{
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': environment.token
    });
    let options = { headers: headers };
    var httpRequest = this.http.put<any>(this.uri + "/" + id, body, options)
      .pipe(catchError(this.handleError));
    return httpRequest;
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
