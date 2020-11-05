import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { SessionBasicInfo } from 'src/app/models/sessions/session-base-info';
import {SessionUserModel} from '../../models/sessions/session-user-model';
import { Guid } from 'guid-typescript';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class SessionService {
  private uri = environment.baseURL+ 'sessions';
  private id = 1;
  private token: Guid;
  constructor(private http: HttpClient  ) { this.readToken(); }

  getAll(): Observable<SessionBasicInfo[]>{
    return this.http.get<SessionBasicInfo[]>(this.uri)
      .pipe(catchError(this.handleError));
  }
  logout() {}

  login(user: SessionUserModel){

    const sessionData = {
      ...user,
    };
    return this.http.post(
      `${ this.uri}`,
      sessionData
    ).pipe(map(resp => {this.saveToken(resp ['token']); return resp; }));
  }
  private saveToken (token: Guid) {
    this.token = token;
    localStorage.setItem('token', token.toString());
  }
  readToken () {
    // if (localStorage.getItem('token'))
    // {
    //   this.token = localStorage.getItem('token');
    // } else
    // {
    //   this.token = '' ;
    // }
    // return this.token;
  }
  private handleError(error: HttpErrorResponse){
    let message: string;
    if (error.error instanceof ErrorEvent) {
      message = 'Error: do it again';
    } else{
      // tslint:disable-next-line: triple-equals
      if (error.status == 0){
        message = 'The server is shutdown';
      } else{
        message = error.error.message;
      }
    }
    return throwError(message);
  }
}
