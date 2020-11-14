import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HouseBasicInfo } from 'src/app/models/house/house-base-info';
import { HouseDetailInfo } from 'src/app/models/house/house-detail-info';
import { TouristPointsBasicInfo } from 'src/app/models/touristpoint/touristpoint-base-info';
import { HouseService } from 'src/app/services/houses/house.service';
import { TouristPointsService } from 'src/app/services/touristpoints/touristpoint.service';

@Component({
  selector: 'app-house-editor',
  templateUrl: './house-editor.component.html',
  styleUrls: ['./house-editor.component.css']
})
export class HouseEditorComponent implements OnInit {
  public house: HouseDetailInfo = {} as HouseDetailInfo;
  public touristPoint: TouristPointsBasicInfo[] = [];
  public houseId: number = 0;
  public pricePerNigth : number;
  public avaible: boolean;
  public existentHouse : boolean;
  public touristPointName: string;
  touristPointNew: TouristPointsBasicInfo = {} as TouristPointsBasicInfo;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private houseService: HouseService,
    private touristPointService: TouristPointsService) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.houseId = Number(id);
    this.existentHouse = this.isExistentHouse();
    if (this.existentHouse) {
      this.houseService.getBy(this.houseId).subscribe(
        houseResponse =>
          this.getBy(houseResponse), (error: string) => this.showError(error));
    }
  }
  updateAvaible(house) {

  }
  isExistentHouse (): boolean {
      return !isNaN(this.houseId);
    }
  addHouse ()
  {

  }
  private getBy(houseResponse: HouseDetailInfo) {
    this.house = houseResponse;
    this.touristPointName = this.house.touristPoint.name;
  }
  private showError(message: string) {
    console.log(message);
  }
}
