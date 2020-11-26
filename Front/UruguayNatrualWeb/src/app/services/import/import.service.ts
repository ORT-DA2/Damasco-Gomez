import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/internal/operators/catchError';
import { ImportBasicInfo } from 'src/app/models/import/import-basic-info';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ImportService {
  private uri = environment.baseURL+'importers';

  constructor(private http: HttpClient) { }

  getNames():Observable<ImportBasicInfo[]>{
    return this.http.get<ImportBasicInfo[]>(this.uri)
      .pipe(catchError(this.handleError));
  }

  post(body): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': localStorage.getItem('token')
    });
    let options = { headers: headers };
    var httpRequest = this.http.post<any>(this.uri, body, options)
      .pipe(catchError(this.handleError));
    return httpRequest;
  }


  private handleError(error: HttpErrorResponse){
    return throwError(error.error);
  }
}
