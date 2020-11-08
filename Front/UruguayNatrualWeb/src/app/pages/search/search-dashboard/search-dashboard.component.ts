import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-search-dashboard',
  templateUrl: './search-dashboard.component.html',
  styleUrls: ['./search-dashboard.component.css']
})
export class SearchDashboardComponent implements OnInit {
  public isRegion: boolean = false;
  public isCategory: boolean = true;

  constructor() { }

  ngOnInit(): void {
  }
  updateCategory(){
    this.isCategory = !this.isCategory;
    this.isRegion = false;
  }
  updateRegion(){
    this.isRegion = !this.isRegion;
    this.isCategory = false;
  }

}
