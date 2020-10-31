import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-booking-dashboard',
  templateUrl: './booking-dashboard.component.html',
  styleUrls: ['./booking-dashboard.component.css']
})
export class BookingDashboardComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  public add(){
    console.log("add wanted");
  }
}
