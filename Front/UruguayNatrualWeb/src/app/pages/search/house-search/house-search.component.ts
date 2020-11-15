import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { HouseBasicInfo } from 'src/app/models/house/house-base-info';
import { HouseService } from 'src/app/services/houses/house.service';

@Component({
  selector: 'app-house-search',
  templateUrl: './house-search.component.html',
  styleUrls: ['./house-search.component.css']
})
export class HouseSearchComponent implements OnInit {
  panelOpenState = false;
  public houses: HouseBasicInfo[] = {} as HouseBasicInfo[];
  touristPointId: string;
  public checkIn: string;
  public checkOut: string;
  checkInValue : string;
  checkOutValue : string;
  public cantAdults: string = '0';
  public cantChildren: string = '0';
  public cantBabies: string = '0';
  public cantSeniors: string = '0';
  public searchDone: boolean = false;

  public myForm: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private houseService: HouseService) { }

  ngOnInit(): void {
    this.touristPointId = (this.route.snapshot.paramMap.get('id'));
  }
  private getAll(houseResponse: HouseBasicInfo[]) {
    this.houses = houseResponse;
    this.searchDone = true;
  }

  private showError(message: string) {
    console.log(message);
  }

  searchBy() {
    this.houseService.getByTouristoPoint(this.checkInValue, this.checkOutValue, this.touristPointId,
      this.cantAdults, this.cantChildren, this.cantBabies, this.cantSeniors).subscribe(
        houseResponse =>
          this.getAll(houseResponse), (error: string) => this.showError(error)
      );
  }

  onChangeCheckIn(event){
    this.checkInValue = this.parseDate(event);
  }
  onChangeCheckOut(event){
    this.checkOutValue = this.parseDate(event);
  }

  private parseDate(date: string){
    var dates = date.split('-');
    const year = dates.length == 3 ? dates[0] : '0';
    const month = dates.length == 3 ? dates[1] : '0';
    const day = dates.length == 3 ? dates[2] : '0';
    return day + '/' + month + '/' + year ;
  }
}
