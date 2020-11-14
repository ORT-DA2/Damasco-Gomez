import { Component, OnInit } from '@angular/core';
import { HouseBasicInfo } from 'src/app/models/house/house-base-info';
import { HouseService } from 'src/app/services/houses/house.service';

@Component({
  selector: 'app-house-table',
  templateUrl: './house-table.component.html',
  styleUrls: ['./house-table.component.css']
})
export class HouseTableComponent implements OnInit {
  public houses: HouseBasicInfo[] = [];
  public id: Number = 0;
  constructor(private houseService: HouseService) { }


  ngOnInit(): void {
  }

}
