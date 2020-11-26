import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { CategoryBasicInfo } from 'src/app/models/category/category-basic-info';
import { CategoryDetailInfo } from 'src/app/models/category/category-detail-info';
@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private uri = environment.baseURL +'categories';
  private id = 1;
  constructor(private http: HttpClient) { }

  getAll():Observable<CategoryBasicInfo[]>{
    return this.http.get<CategoryBasicInfo[]>(this.uri)
      .pipe(catchError(this.handleError));
  }

  getBy (id): Observable<CategoryDetailInfo>{
    return this.http.get<CategoryDetailInfo>(this.uri + '/' + id)
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

  add(body):Observable<any>{
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization':  localStorage.getItem('token')
    });
    let options = { headers: headers };
    var httpRequest = this.http.post<any>(this.uri , body, options)
      .pipe(catchError(this.handleError));
    return httpRequest;
  }

  private handleError(error: HttpErrorResponse) {
    return throwError(error.error);
  }

}
