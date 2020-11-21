import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CategoryBasicInfo } from 'src/app/models/category/category-basic-info';
import { ImageTouristPointBasic } from 'src/app/models/imagetouristpoint/Imagetourispoint-base-info';
import { RegionBasicInfo } from 'src/app/models/regions/region-base-info';
import { TouristPointDetailInfo } from 'src/app/models/touristpoint/tourist-point-detail-info';
import { TouristPointsBasicInfo } from 'src/app/models/touristpoint/touristpoint-base-info';
import { CategoryService } from 'src/app/services/categories/category.service';
import { RegionService } from 'src/app/services/regions/region.service';
import { TouristPointsService } from 'src/app/services/touristpoints/touristpoint.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-tourist-point-editor',
  templateUrl: './tourist-point-editor.component.html',
  styleUrls: ['./tourist-point-editor.component.css']
})
export class TouristPointEditorComponent implements OnInit {
  public touristPoint: TouristPointDetailInfo = {} as TouristPointDetailInfo;
  public regions: RegionBasicInfo[] = [];
  public categories: CategoryBasicInfo[] = [];
  public touristPointId: number = 0;
  public regionName: string = "";
  public imageName : string;
  public categoriesName: string[] = [];
  public sourceImage : string = environment.imageURL;
  public imageTP: ImageTouristPointBasic = {} as ImageTouristPointBasic ;
  categoryNew: CategoryBasicInfo = {} as CategoryBasicInfo;

  constructor(
    private route: ActivatedRoute,
    private touristPointService: TouristPointsService,
    private regionService: RegionService,
    private categoryService: CategoryService
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.touristPointId = Number(id);
    this.touristPoint.categories = [];
    this.touristPointService.getBy(this.touristPointId).subscribe(
      touristPointResponse =>
        this.getBy(touristPointResponse), (error: string) => this.showError(error));
    this.regionService.getAll().subscribe(
      regionResponse =>
        this.getAllRegions(regionResponse), (error: string) =>this.showError(error));
    this.categoryService.getAll().subscribe(
      categoryResponse =>
        this.getAllCategories(categoryResponse), (error: string) =>this.showError(error));




  }

  private getBy(touristPointResponse: TouristPointDetailInfo){
    this.touristPoint = touristPointResponse;
    this.imageName = this.touristPoint.image.name;
    this.imageTP = this.touristPoint.image;
    this.imageName = this.sourceImage + '/' + this.imageTP.name;



    this.categoriesName = this.touristPoint.categories? this.touristPoint.categories.map(category => category.name)
      : [];
  }
  private getAllRegions(regionResponse: RegionBasicInfo[]){
    this.regions = regionResponse;
    const regionWithId = this.regions.find(x => x.id === this.touristPoint.regionId);
    this.regionName = regionWithId ? regionWithId.name : "";
  }
  private getAllCategories(categoryResponse: CategoryBasicInfo[]){
    this.categories = categoryResponse;
  }

  updateData(touristPoint : TouristPointDetailInfo){
    const basicInfo = this.createModel(touristPoint);
    this.touristPointService.update(this.touristPointId, basicInfo).subscribe(
      responseUpdate =>
        console.log(responseUpdate)
    );
  }

  onChangeRegionName(event: any){
    this.touristPoint.region = this.regions.find(x => this.regionName == x.name);
    this.touristPoint.regionId = this.touristPoint.region.id;
  }

  onChangeCategoryName(categoryName: string, index: number){
    var categoryId = this.categories.find(x => x.name == categoryName);
    this.touristPoint.categories[index] = categoryId;
  }

  addCategory(){
    this.touristPoint.categories = this.touristPoint.categories.concat(this.categoryNew);
  }

  deleteCategory(){
    this.touristPoint.categories.splice(-1,1);
    this.categoriesName.splice(-1,1);
  }

  private createModel(touristPoint : TouristPointDetailInfo) : TouristPointsBasicInfo{
    let modelBase : TouristPointsBasicInfo = {} as TouristPointsBasicInfo ;
    modelBase.categories = touristPoint.categories.map(x=> x.id);
    modelBase.description = touristPoint.description;
    modelBase.image = touristPoint.image;
    modelBase.name = touristPoint.name;
    modelBase.regionId = touristPoint.regionId;
    return modelBase;
  }
  private showError(message: string){
    console.log(message);
  }

}
