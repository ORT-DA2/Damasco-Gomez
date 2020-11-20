import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ReviewBasicInfo } from 'src/app/models/reviews/review-base-info';



@Injectable({
  providedIn: 'root'
})
export class ReviewService {
  private uri = environment.baseURL+ 'reviews';
  private id = 1;
  constructor(private http: HttpClient) { }

  getAll():Observable<ReviewBasicInfo[]>{
    return this.http.get<ReviewBasicInfo[]>(this.uri)
      .pipe(catchError(this.handleError));
  }


  add(body): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    let options = { headers: headers };
    var httpRequest = this.http.post<any>(this.uri, body, options)
      .pipe(catchError(this.handleError));
    return httpRequest;
  }


  private handleError(error: HttpErrorResponse){
    let message: string;
    if (error.error instanceof ErrorEvent) {
      message = 'Error: do it again';
    } else{
      // tslint:disable-next-line: triple-equals
      if(error.status == 0){
        message = 'The server is shutdown';
      } else{
        message = error.error.message;
      }
    }
    return throwError(message);
  }
}
