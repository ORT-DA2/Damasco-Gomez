import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryBasicInfo } from 'src/app/models/category/category-basic-info';
import { ImageTouristPointBasic } from 'src/app/models/imagetouristpoint/Imagetourispoint-base-info';
import { RegionBasicInfo } from 'src/app/models/regions/region-base-info';
import { TouristPointDetailInfo } from 'src/app/models/touristpoint/tourist-point-detail-info';
import { CategoryService } from 'src/app/services/categories/category.service';
import { RegionService } from 'src/app/services/regions/region.service';
import { TouristPointsService } from 'src/app/services/touristpoints/touristpoint.service';
import { environment } from 'src/environments/environment';
import { TouristPointInInfo } from 'src/app/models/touristpoint/tourist-point-in-info';

@Component({
  selector: 'app-tourist-point-editor',
  templateUrl: './tourist-point-editor.component.html',
  styleUrls: ['./tourist-point-editor.component.css']
})
export class TouristPointEditorComponent implements OnInit {
  public touristPoint: TouristPointDetailInfo = {} as TouristPointDetailInfo;
  public touristPointIn: TouristPointInInfo = {} as TouristPointInInfo;
  public regions: RegionBasicInfo[] = [];
  public categories: CategoryBasicInfo[] = [];
  public touristPointId: number = 0;
  public regionName: string = '';
  public image: ImageTouristPointBasic = {} as ImageTouristPointBasic;
  public imageName: string;
  public categoriesName: string[] = [];
  public sourceImage: string = '';
  public existTP: boolean = false;
  public selectedFile: File = null;
  public showImageSelector: boolean;
  categoryNew: CategoryBasicInfo = {} as CategoryBasicInfo;
  public errorMessageBackend: string = '';
  public updateMessage: string = '';

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private touristPointService: TouristPointsService,
    private regionService: RegionService,
    private categoryService: CategoryService,
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.touristPointId = Number(id);
    this.touristPoint.categories = [];
    this.existTP = this.isExistentTouristPoint();
    if (this.existTP) {
      this.touristPointService.getBy(this.touristPointId)
        .subscribe(
          touristPointResponse => {
            this.getBy(touristPointResponse);
          },
          catchError => {
            this.errorMessageBackend = catchError + ', fix it and try again';
          }
        );
    }
    this.regionService.getAll()
      .subscribe(
        regionResponse => {
          this.getAllRegions(regionResponse);
        },
        catchError => {
          this.errorMessageBackend = catchError + ', fix it and try again';
        }
      );
    this.categoryService.getAll()
      .subscribe(
        categoryResponse => {
          this.getAllCategories(categoryResponse);
        },
        catchError => {
          this.errorMessageBackend = catchError + ', fix it and try again';
        }
      );

  }

  private isExistentTouristPoint(): boolean {
    return !isNaN(this.touristPointId);
  }
  private getBy(touristPointResponse: TouristPointDetailInfo) {
    this.touristPoint = touristPointResponse;
    this.image = this.touristPoint.image;
    this.sourceImage = environment.imageURL + this.touristPoint.image.name;
    this.categoriesName = this.touristPoint.categories ? this.touristPoint.categories.map(category => category.name)
      : [];
  }
  onSelectFile(event) {
    this.selectedFile = event.target.files[0];
    this.imageName = this.selectedFile.name;
    this.sourceImage = environment.imageURL + this.imageName;
  }


  private getAllRegions(regionResponse: RegionBasicInfo[]) {
    this.regions = regionResponse;
    const regionWithId = this.regions.find(x => x.id === this.touristPoint.regionId);
    this.regionName = regionWithId ? regionWithId.name : '';
  }
  private getAllCategories(categoryResponse: CategoryBasicInfo[]) {
    this.categories = categoryResponse;
  }
  addTouristPoint() {
    var touristPoint = this.touristPoint;
    const basicInfo = this.createModel(touristPoint);
    this.touristPointService.add(basicInfo)
      .subscribe(
        responseResponse => {
          this.touristPointId = responseResponse.id;
          this.sourceImage = environment.imageURL + responseResponse.image.name;
          this.router.navigateByUrl(`/tourist-points/tourist-point-editor/${this.touristPointId}`);
          this.existTP = true;
          this.errorMessageBackend = '';
          this.updateMessage = 'Added!'
        },
        catchError => {
          this.errorMessageBackend = catchError + ', fix it and try again';
        }
      );
  }
  updateData() {
    var touristPoint = this.touristPoint;
    const basicInfo = this.createModel(touristPoint);
    this.touristPointService.update(this.touristPointId, basicInfo)
      .subscribe(
        responseResponse => {
          this.sourceImage = environment.imageURL + responseResponse.image.name;
          this.updateMessage = 'Update is done!';
          this.errorMessageBackend = '';
        },
        catchError => {
          this.errorMessageBackend = catchError + ', fix it and try again';
        }
      );
  }

  onChangeRegionName(event: any) {
    this.touristPoint.region = this.regions.find(x => this.regionName == x.name);
    this.touristPoint.regionId = this.touristPoint.region.id;
  }

  onChangeCategoryName(categoryName: string, index: number) {
    var categoryId = this.categories.find(x => x.name == categoryName);
    this.touristPoint.categories[index] = categoryId;
  }

  addCategory() {
    this.touristPoint.categories = this.touristPoint.categories.concat(this.categoryNew);
  }

  deleteCategory() {
    this.touristPoint.categories.splice(-1, 1);
    this.categoriesName.splice(-1, 1);
  }

  private createModel(touristPoint: any): TouristPointInInfo {
    let modelBase: TouristPointInInfo = {} as TouristPointInInfo;
    modelBase.categories = touristPoint.categories.map(x => x.id);
    modelBase.description = touristPoint.description;
    modelBase.image = this.imageName;
    modelBase.name = touristPoint.name;
    modelBase.regionId = touristPoint.regionId;
    return modelBase;
  }

}
