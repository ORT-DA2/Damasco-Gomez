import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { TouristPointsBasicInfo } from 'src/app/models/touristpoint/touristpoint-base-info';
import { TouristPointDetailInfo } from 'src/app/models/touristpoint/tourist-point-detail-info';

@Injectable({
  providedIn: 'root'
})
export class TouristPointsService {
  private uri = environment.baseURL+'touristpoints';
  private id = 1;
  constructor(private http: HttpClient) { }

  getAll():Observable<TouristPointsBasicInfo[]>{
    return this.http.get<TouristPointsBasicInfo[]>(this.uri)
      .pipe(catchError(this.handleError));
  }

  getBy(id):Observable<TouristPointDetailInfo>{
    var httpRequest =
    this.http.get<TouristPointDetailInfo>(this.uri + "/" + id)
        .pipe(catchError(this.handleError));
    return httpRequest;
  }

  add():Observable<any>{
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': localStorage.getItem('token'), });
    let options = { headers: headers };
    const body=JSON.stringify("");
    return this.http.post(this.uri,body,options).pipe(catchError(this.handleError));
  }

  delete(id):Observable<any>{
    const headers = new HttpHeaders({
      'Authorization':  localStorage.getItem('token'),
      'Content-Type':'application/json'
    });
    let options = { headers: headers };
    var httpRequest = this.http.delete<any>(this.uri + "/" + id,options)
      .pipe(catchError(this.handleError));
    return httpRequest;
  }

  update(id, body):Observable<any>{
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization':  localStorage.getItem('token')
    });
    let options = { headers: headers };
    var httpRequest = this.http.put<any>(this.uri + '/' + id, body, options)
      .pipe(catchError(this.handleError));
    return httpRequest;
  }


  private handleError(error: HttpErrorResponse){
    let message: string;
    if (error.error instanceof ErrorEvent) {
      message = 'Error: do it again';
    } else{
      if(error.status == 0){
        message = 'The server is shutdown';
      }else{
        message = error.error.message;
      }
    }
    return throwError(message);
  }
}
