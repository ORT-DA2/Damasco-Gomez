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


  GetHousesReportBy(touristPointId: string, dateFromParse: string, dateOutParse: string)
    : Observable<ReportBasicInfo[]> {
      let params = new HttpParams()
      .set('idTp', touristPointId)
      .set('dateFrom', dateFromParse)
      .set('dateOut', dateOutParse);
    return this.http.get<ReportBasicInfo[]>(this.uri, {params}); }

  private handleError(error: HttpErrorResponse){
    return throwError(error.error);
  }
}
