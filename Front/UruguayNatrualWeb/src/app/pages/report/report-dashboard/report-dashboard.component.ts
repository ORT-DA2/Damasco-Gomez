import { BoundElementPropertyAst } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ReportBasicInfo } from 'src/app/models/report/report-base-info';
import { ReportInfoIn } from 'src/app/models/report/report-info-in';
import { TouristPointsBasicInfo } from 'src/app/models/touristpoint/touristpoint-base-info';
import { ReportService } from 'src/app/services/reports/report.service';
import { TouristPointsService } from 'src/app/services/touristpoints/touristpoint.service';

@Component({
  selector: 'app-report-dashboard',
  templateUrl: './report-dashboard.component.html',
  styleUrls: ['./report-dashboard.component.css']
})
export class ReportDashboardComponent implements OnInit {
  public touristPoints: TouristPointsBasicInfo[] = [];
  public touristPointName: string;
  public touristPointId :number;
  public dateFrom: string;
  public dateOut :string;
  public errorMessageDates: string = '';
  public showReports :boolean;
  public checkIParse :string;
  public checkOutParse : string;
  public reports : ReportBasicInfo [] = [];
  constructor( private touristPointService: TouristPointsService , private reportService: ReportService) { }

  ngOnInit(): void {
    this.touristPointService.getAll().subscribe(
      touristPointResponse =>
        this.getAllTouristPoints(touristPointResponse), (error: string) => this.showError(error)
    );
  }
  onChangeTouristPointName(touristPointName: string) {

    var touristPoint = this.touristPoints.find(x => x.name == touristPointName);
    this.touristPointName =  touristPoint.name;
    this.touristPointId = touristPoint.id;

  }
  onChangeCheckIn(checkIn){
    this.checkIParse = this.parseDate(checkIn);
  }
  onChangeCheckOut(checkOut){
    this.checkOutParse = this.parseDate(checkOut);
  }

  private parseDate(date: string) {
    const dates = date.split('-');
    // tslint:disable-next-line: triple-equals
    const year = dates.length == 3 ? dates[0] : '0';
    // tslint:disable-next-line: triple-equals
    const month = dates.length == 3 ? dates[1] : '0';
    // tslint:disable-next-line: triple-equals
    const day = dates.length == 3 ? dates[2] : '0';
    return day + '/' + month + '/' + year;
  }

  private getAllTouristPoints(touristPointResponse: TouristPointsBasicInfo[]) {
    this.touristPoints = touristPointResponse;
  }
  private getAllReports(reportResponse: ReportBasicInfo[]) {
    this.reports = reportResponse;
    this.showReports = true;
  }
  private getReportByTp(){
    const checkInDate = new Date(this.dateFrom);
    const checkOutDate = new Date(this.dateOut);
    if (checkInDate < checkOutDate) {
        this.reportService.GetHousesReportBy(this.touristPointId.toString(), this.checkIParse, this.checkOutParse).subscribe(
            reportResponse =>
              this.getAllReports(reportResponse), (error: string) => this.showError(error)
          );
        this.errorMessageDates = '';
    }
    else {
      this.errorMessageDates = 'Error in the dates, check them please';
    }
  }

  private showError(message: string) {
    console.log(message);
  }

}
