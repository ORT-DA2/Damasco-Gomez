import { Component, OnInit } from '@angular/core';
import { TouristPointsBasicInfo } from 'src/app/models/touristpoint/touristpoint-base-info';
import { TouristPointsService } from 'src/app/services/touristpoints/touristpoint.service';

@Component({
  selector: 'app-tourist-points-table',
  templateUrl: './tourist-points-table.component.html',
  styleUrls: ['./tourist-points-table.component.css']
})
export class TouristPointsTableComponent implements OnInit {
  public touristpoints: TouristPointsBasicInfo[] = [];
  public id: Number = 0;
  public errorMessageBackend: string = '';

  constructor(private touristPointService: TouristPointsService) { }

  ngOnInit(): void {
    this.touristPointService.getAll().subscribe(
      touristPointResponse =>
        this.getAll(touristPointResponse), (error: string) => this.showError(error)
    );
  }

  private getAll(touristPointResponse: TouristPointsBasicInfo[]){
    this.touristpoints = touristPointResponse;
  }

  private showError(message: string){
    this.errorMessageBackend = message;
  }

  private delete(event) {
    this.id = event.id;
    this.touristPointService.delete(this.id).subscribe(
      touristPointResponse =>
        this.delete(touristPointResponse), (error: string) => this.showError(error)
    );
    // tslint:disable-next-line: triple-equals
    this.touristpoints = this.touristpoints.filter(item => item.id != this.id);
  }

}
