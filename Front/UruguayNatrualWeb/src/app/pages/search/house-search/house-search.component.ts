import { Component, OnInit} from '@angular/core';
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

  public myForm: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private houseService: HouseService) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.houseService.getAll().subscribe(
      houseResponse =>
        this.getAll(houseResponse), (error: string) => this.showError(error)
    );
  }
  private getAll(houseResponse: HouseBasicInfo[]){
    this.houses = houseResponse;
  }

  private showError(message: string){
    console.log(message);
  }


}
