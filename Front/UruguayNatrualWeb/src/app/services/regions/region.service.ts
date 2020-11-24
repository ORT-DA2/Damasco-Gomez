import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { RegionBasicInfo } from 'src/app/models/regions/region-base-info';

@Injectable({
  providedIn: 'root'
})
export class RegionService {
  private uri = environment.baseURL+'regions';
  private id = 1;
  constructor(private http: HttpClient) { }

  getAll():Observable<RegionBasicInfo[]>{
    return this.http.get<RegionBasicInfo[]>(this.uri)
      .pipe(catchError(this.handleError));
  }

  getBy (id): Observable<RegionBasicInfo>{
    return this.http.get<RegionBasicInfo>(this.uri + '/' + id)
      .pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse){
    return throwError(error.error);
  }
}
