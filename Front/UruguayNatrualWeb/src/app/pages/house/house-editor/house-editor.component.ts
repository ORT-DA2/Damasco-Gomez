import { Component, OnInit } from '@angular/core';
import { HouseBasicInfo } from 'src/app/models/house/house-base-info';
import { TouristPointsBasicInfo } from 'src/app/models/touristpoint/touristpoint-base-info';

@Component({
  selector: 'app-house-editor',
  templateUrl: './house-editor.component.html',
  styleUrls: ['./house-editor.component.css']
})
export class HouseEditorComponent implements OnInit {
  public house: HouseBasicInfo = {} as HouseBasicInfo;
  public touristPoints: TouristPointsBasicInfo[] = [];
  public houseId: number = 0;
  public pricePerNigth : number;
  public avaible: boolean;
  public touristPointsNames: string[] = [];
  touristPointNew: TouristPointsBasicInfo = {} as TouristPointsBasicInfo;
  constructor() { }

  ngOnInit(): void {
  }
  updateAvaible(house) {

  }
}
