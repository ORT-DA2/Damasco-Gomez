import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/internal/operators/catchError';
import { StateBasicInfo } from 'src/app/models/state/state-base-info';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StatesService {
  private uri = environment.baseURL+'states';
  constructor(private http: HttpClient) { }

  getAll():Observable<StateBasicInfo[]>{
    return this.http.get<StateBasicInfo[]>(this.uri)
      .pipe(catchError(this.handleError));
  }


  private handleError(error: HttpErrorResponse){
    return throwError(error.error);
  }
}
