import { Component, OnInit } from '@angular/core';
import { HouseBasicInfo } from 'src/app/models/house/house-base-info';

@Component({
  selector: 'app-report-table',
  templateUrl: './report-table.component.html',
  styleUrls: ['./report-table.component.css']
})
export class ReportTableComponent implements OnInit {
  public houses: HouseBasicInfo[] = {} as HouseBasicInfo[];
  constructor() { }

  ngOnInit(): void {
  }

}
