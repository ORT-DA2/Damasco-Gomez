import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TouristPointsBasicInfo } from 'src/app/models/touristpoint/touristpoint-base-info';
import { TouristPointsService } from 'src/app/services/touristpoints/touristpoint.service';
const REGION : string = "region";

@Component({
  selector: 'app-table-tourist-points',
  templateUrl: './table-tourist-points.component.html',
  styleUrls: ['./table-tourist-points.component.css']
})
export class TableTouristPointsComponent implements OnInit {
  public touristPoints: TouristPointsBasicInfo[] = [];
  public isRegion : boolean ;
  public by : string;
  public id : number;
  public errorMessageBackend: string = '';

  constructor(private route: ActivatedRoute,private touristPointService: TouristPointsService) {
    this.by = this.route.snapshot.paramMap.get('name');
    this.id = parseInt(this.route.snapshot.paramMap.get('id'));
    this.isRegion = this.by == REGION;
   }

  ngOnInit(): void {
    this.touristPointService.getAll()
    .subscribe(
      touristPointResponse => {
        this.getAll(touristPointResponse);
      },
      catchError => {
        this.errorMessageBackend = catchError.error + ', fix it and try again';
      }
    );
  }

  private getAll(touristPointResponse: TouristPointsBasicInfo[]){
    this.touristPoints = this.isRegion ?
      touristPointResponse.filter(x =>(x.regionId == this.id) ) :
      touristPointResponse.filter(y => y.categories.filter( j => j == this.id));
  }
}
