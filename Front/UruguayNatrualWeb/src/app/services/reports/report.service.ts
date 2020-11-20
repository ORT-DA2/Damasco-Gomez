import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ReportBasicInfo } from 'src/app/models/report/report-base-info';


@Injectable({
  providedIn: 'root'
})
export class ReportService {
  private uri = environment.baseURL+ 'reports';
  private id = 1;
  constructor(private http: HttpClient) { }

  getAll():Observable<ReportBasicInfo[]>{
    return this.http.get<ReportBasicInfo[]>(this.uri)
      .pipe(catchError(this.handleError));
  }


  GetHousesReportBy(touristPointId: string, CheckInParse: string, CheckOutParse: string)
    : Observable<ReportBasicInfo[]> {
      const headers = new HttpHeaders({
        'Authorization': localStorage.getItem('token'),
        'Content-Type': 'application/json'
      });
      let params = new HttpParams()
      .set('touristpointId', touristPointId)
      .set('checkin', CheckInParse)
      .set('checkout', CheckOutParse);
    return this.http.get<ReportBasicInfo[]>(this.uri,  {headers: headers, params: params}); }


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
