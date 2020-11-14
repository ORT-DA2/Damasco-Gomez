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
    this.houseService.getAll().subscribe(
      response =>
        this.getAll(response), (error: string) => this.showError(error)
    );
  }

  private getAll(response: HouseBasicInfo[]){
    this.houses = response;
  }

  private showError(message: string){
    console.log(message);
  }

  private delete(event) {
    this.id = event.id;
    this.houseService.delete(this.id).subscribe(
      response =>
        this.delete(response), (error: string) => this.showError(error) ,
    );

    this.houses = this.houses.filter(item => item.id != this.id);
  }

}
