import { Component, Input, OnInit } from '@angular/core';
import { TouristPointsBasicInfo } from 'src/app/models/touristpoint/touristpoint-base-info';
import { TouristPointsService } from 'src/app/services/touristpoints/touristpoint.service';

@Component({
  selector: 'app-table-tourist-points',
  templateUrl: './table-tourist-points.component.html',
  styleUrls: ['./table-tourist-points.component.css']
})
export class TableTouristPointsComponent implements OnInit {
  public touristPoints: TouristPointsBasicInfo[] = [];

  public by : string;
  public id : string;

  constructor(private touristPointService: TouristPointsService) { }

  ngOnInit(): void {
    this.touristPointService.getAll().subscribe(
      touristPointResponse =>
        this.getAll(touristPointResponse), (error: string) => this.showError(error)
    );
  }

  private getAll(touristPointResponse: TouristPointsBasicInfo[]){
    this.touristPoints = touristPointResponse;
  }

  private showError(message: string){
    console.log(message);
  }
  chooseRegion(event){
    console.log(event);
  }
}
