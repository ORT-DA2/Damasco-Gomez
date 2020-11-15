import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { HouseBasicInfo } from 'src/app/models/house/house-base-info';
import { HouseDetailInfo } from 'src/app/models/house/house-detail-info';

@Injectable({
  providedIn: 'root'
})
export class HouseService {
  private uri = environment.baseURL + 'houses';
  private id = 1;
  constructor(private http: HttpClient) { }

  getAll(): Observable<HouseBasicInfo[]> {
    return this.http.get<HouseBasicInfo[]>(this.uri)
      .pipe(catchError(this.handleError));
  }

  getByTouristoPoint(CheckIn: string, CheckOut: string,
    TouristPointId: string, CantAdults: string,
    CantChildren: string, CantBabies: string, CantSeniors: string)
    : Observable<HouseBasicInfo[]> {
    let params = new HttpParams()
      .set('checkin', CheckIn)
      .set('checkout', CheckOut)
      .set('touristpointId', TouristPointId)
      .set('cantadults', CantAdults)
      .set('cantchildrens', CantChildren)
      .set('cantbabys', CantBabies)
      .set('cantSeniors', CantSeniors);
    return this.http.get<HouseBasicInfo[]>(this.uri, { params });
  }

  delete(id): Observable<any> {
    const headers = new HttpHeaders({
      'Authorization': localStorage.getItem('token'),
      'Content-Type': 'application/json'
    });
    let options = { headers: headers };
    var httpRequest = this.http.delete<any>(this.uri + '/' + id, options)
      .pipe(catchError(this.handleError));
    return httpRequest;

  }
  updateAvailable(id, body) {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': localStorage.getItem('token')
    });
    let options = { headers: headers };
    var httpRequest = this.http.put<any>(this.uri + '/' + id, body, options)
      .pipe(catchError(this.handleError));
    return httpRequest;
  }

  add(body): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': localStorage.getItem('token')
    });
    let options = { headers: headers };
    var httpRequest = this.http.post<any>(this.uri, body, options)
      .pipe(catchError(this.handleError));
    return httpRequest;
  }

  getBy(id): Observable<HouseDetailInfo> {
    return this.http.get<HouseDetailInfo>(this.uri + '/' + id)
      .pipe(catchError(this.handleError));
  }
  private handleError(error: HttpErrorResponse) {
    let message: string;
    if (error.error instanceof ErrorEvent) {
      message = 'Error: do it again';
    } else {
      if (error.status == 0) {
        message = 'The server is shutdown';
      } else {
        message = error.error.message;
      }
    }
    return throwError(message);
  }
}
