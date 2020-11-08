import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-table-tourist-points',
  templateUrl: './table-tourist-points.component.html',
  styleUrls: ['./table-tourist-points.component.css']
})
export class TableTouristPointsComponent implements OnInit {

  @Input()
  public by : string;
  @Input()
  public id : string;

  constructor() { }

  ngOnInit(): void {
  }

}
