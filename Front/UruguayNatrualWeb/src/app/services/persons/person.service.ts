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
  logout() { }

  newUser(user: PersonBasicInfo) {
    const personData = {
      ...user,
    };
    return this.http.post(
      `${this.uri}`,
      personData
    );
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


  private handleError(error: HttpErrorResponse) {
    let message: string;
    if (error.error instanceof ErrorEvent) {
      message = 'Error: do it again';
    } else {
      // tslint:disable-next-line: triple-equals
      if (error.status == 0) {
        message = 'The server is shutdown';
      } else {
        message = error.error.message;
      }
    }
    return throwError(message);
  }
}
