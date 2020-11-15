import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryBasicInfo } from 'src/app/models/category/category-basic-info';
import { HouseBasicInfo } from 'src/app/models/house/house-base-info';
import { HouseDetailInfo } from 'src/app/models/house/house-detail-info';
import { RegionBasicInfo } from 'src/app/models/regions/region-base-info';
import { TouristPointsBasicInfo } from 'src/app/models/touristpoint/touristpoint-base-info';
import { CategoryService } from 'src/app/services/categories/category.service';
import { HouseService } from 'src/app/services/houses/house.service';
import { RegionService } from 'src/app/services/regions/region.service';
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
  public readonly : boolean;
  public regionName: string;
  public categoriesName: string[] = [];
  public categories : CategoryBasicInfo[] = [];
  touristPointNew: TouristPointsBasicInfo = {} as TouristPointsBasicInfo;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private houseService: HouseService,
    private regionService: RegionService,
    private categoryService: CategoryService,
    private touristPointService: TouristPointsService) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.houseId = Number(id);
    this.existentHouse = this.isExistentHouse();
    this.readonly = this.isReadOnly();
    console.log( this.readonly);
    if (this.existentHouse) {
      this.houseService.getBy(this.houseId).subscribe(
        houseResponse =>
          this.getBy(houseResponse), (error: string) => this.showError(error));
    }
    this.regionService.getBy(this.house.touristPoint.regionId).subscribe(
      response =>
        this.getRegionNameBy(response), (error: string) => this.showError(error));
        this.categoryService.getAll().subscribe(
          categoryResponse =>
            this.getAllCategories(categoryResponse), (error: string) =>this.showError(error));
  }

  isExistentHouse (): boolean {
      return !isNaN(this.houseId);
    }

    updateAvailable(house: HouseDetailInfo) {
    const basicInfo = this.createModel(house);
    this.houseService.updateAvailable(this.houseId, basicInfo).subscribe(
      responseUpdate =>
        console.log(responseUpdate)
    );
  }
  addHouse(house: HouseDetailInfo) {
    const basicInfo = this.createModel(house);
    this.houseService.add(basicInfo).subscribe(
      responseAdd => {
        this.houseId= responseAdd.id;
        this.router.navigateByUrl(`/category/category-editor/${this.houseId}`);
        this.existentHouse = true;
      }
    );
  }
  isReadOnly () : boolean{
    return !isNaN(this.houseId);
  }
  private createModel(house: HouseDetailInfo): HouseBasicInfo {
    const modelBase: HouseBasicInfo = {} as HouseBasicInfo;
    modelBase.name = house.name;
    modelBase.touristPointId = house.touristPoint.id;
    return modelBase;
  }
  private getBy(houseResponse: HouseDetailInfo) {
    this.house = houseResponse;
  }
  private showError(message: string) {
    console.log(message);
  }

  getRegionNameBy(event: any){
    this.regionName = event.name;
  }
  getAllCategories (categoryResponse: any){
      this.categories = categoryResponse;

  }

}
