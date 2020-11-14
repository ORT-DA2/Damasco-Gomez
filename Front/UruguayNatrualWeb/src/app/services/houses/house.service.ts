import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { HouseBasicInfo } from 'src/app/models/house/house-base-info';

@Injectable({
  providedIn: 'root'
})
export class HouseService {
  private uri = environment.baseURL+'houses';
  private id = 1;
  constructor(private http: HttpClient) { }

  getAll():Observable<HouseBasicInfo[]>{
    return this.http.get<HouseBasicInfo[]>(this.uri)
      .pipe(catchError(this.handleError));
  }
  delete(id):Observable<any>{
    const headers = new HttpHeaders({
      'Authorization':  localStorage.getItem('token'),
      'Content-Type':'application/json'
    });
    let options = { headers: headers };
    var httpRequest = this.http.delete<any>(this.uri + '/' + id,options)
      .pipe(catchError(this.handleError));
    return httpRequest;

  }
  getBy (id): Observable<HouseBasicInfo>{
    return this.http.get<HouseBasicInfo>(this.uri + '/' + id)
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
