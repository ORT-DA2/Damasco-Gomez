import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { PersonBasicInfo } from 'src/app/models/person/person-base-info';


@Injectable({
  providedIn: 'root'
})
export class PersonService {
  private uri = environment.baseURL + 'persons';
  constructor(private http: HttpClient) { }

  getAll(): Observable<PersonBasicInfo[]> {
    return this.http.get<PersonBasicInfo[]>(this.uri)
      .pipe(catchError(this.handleError));
  }

  getBy(id): Observable<PersonBasicInfo>{
    return this.http.get<PersonBasicInfo>(this.uri + '/' + id)
    .pipe(catchError(this.handleError));
  }

  newUser(user):Observable<PersonBasicInfo> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });
    let options = { headers: headers };
    var httpRequest = this.http.post<any>(this.uri, user, options)
      .pipe(catchError(this.handleError));
    return httpRequest;
  }

  update(id, body):Observable<PersonBasicInfo>{
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization':  localStorage.getItem('token')
    });
    let options = { headers: headers };
    var httpRequest = this.http.put<PersonBasicInfo>(this.uri + '/' + id, body, options)
      .pipe(catchError(this.handleError));
    return httpRequest;
  }

  delete(id): Observable<PersonBasicInfo> {
    const headers = new HttpHeaders({
      'Authorization': localStorage.getItem('token'),
      'Content-Type': 'application/json'
    });
    let options = { headers: headers };
    var httpRequest = this.http.delete<PersonBasicInfo>(this.uri + '/' + id, options)
      .pipe(catchError(this.handleError));
    return httpRequest;
  }

  private handleError(error: HttpErrorResponse) {
    return throwError(error.error);
  }
}
