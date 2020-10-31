import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { TouristPointsBasicInfo } from 'src/app/models/touristpoint/touristpoint-base-info';

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
