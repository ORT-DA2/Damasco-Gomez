import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryBasicInfo } from 'src/app/models/category/category-basic-info';
import { HouseBasicInfo } from 'src/app/models/house/house-base-info';
import { HouseDetailInfo } from 'src/app/models/house/house-detail-info';
import { HouseModelIn } from 'src/app/models/house/house-model-in';
import { ImageHouseBasicModel } from 'src/app/models/image-house/image-house-basic';
import { TouristPointsBasicInfo } from 'src/app/models/touristpoint/touristpoint-base-info';
import { CategoryService } from 'src/app/services/categories/category.service';
import { HouseService } from 'src/app/services/houses/house.service';
import { RegionService } from 'src/app/services/regions/region.service';
import { TouristPointsService } from 'src/app/services/touristpoints/touristpoint.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-house-editor',
  templateUrl: './house-editor.component.html',
  styleUrls: ['./house-editor.component.css']
})
export class HouseEditorComponent implements OnInit {
  public house: HouseDetailInfo = {} as HouseDetailInfo;
  public touristPoints: TouristPointsBasicInfo[] = [];
  public houseId: number = 0;
  public pricePerNigth: number;
  public starts: number;
  public existentHouse: boolean;
  public readonly: boolean;
  public regionName: string;
  public touristPointName: string;
  public touristPointId: number;
  public showImageSelector: boolean;
  public categoriesName: string[] = [];
  public startsList: number[] = [];
  public categories: CategoryBasicInfo[] = [];
  public imageHouse: string;
  public selectedFile: File;
  public images: ImageHouseBasicModel[];
  public imagesNames: string[] = [];
  public imageName: string;
  public selectedFiles: FileList;
  public sourceImage: string = environment.imageURL;
  public updateMessage: string = '';
  public errorBackend: string = '';

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
    this.startsList = [1, 2, 3, 4, 5];
    this.existentHouse = this.isExistentHouse();
    this.readonly = this.isReadOnly();
    if (this.existentHouse) {
      this.houseService.getBy(this.houseId).subscribe(
        houseResponse =>
          this.getBy(houseResponse), (error: string) => this.showError(error));
    }
    this.touristPointService.getAll().subscribe(
      touristPointResponse =>
        this.getAllTouristPoints(touristPointResponse), (error: string) => this.showError(error)
    );
  }

  isExistentHouse(): boolean {
    return !isNaN(this.houseId);
  }

  updateAvailable(house: HouseBasicInfo) {
    const basicInfo = this.createModel(house);
    this.houseService.updateAvailable(this.houseId, basicInfo).subscribe(
      responseUpdate =>
        this.updateMessage = 'Update done!'
    );
  }

  addHouse(house: HouseBasicInfo) {

    const basicInfo = this.createModel(house);
    console.log(basicInfo);
    this.houseService.add(basicInfo).subscribe(
      responseAdd => {
        this.houseId = responseAdd.id;
        this.router.navigateByUrl(`/houses/house-editor/${this.houseId}`);
        this.existentHouse = true;
      }
    );
  }
  isReadOnly(): boolean {
    return !isNaN(this.houseId);
  }
  private createModel(house: HouseBasicInfo): HouseModelIn {
    const modelBase: HouseModelIn = {} as HouseModelIn;
    modelBase.name = house.name;
    modelBase.starts = house.starts;
    modelBase.pricePerNight = house.pricePerNight;
    modelBase.avaible = house.avaible;
    modelBase.address = house.address;
    modelBase.description = house.description;
    modelBase.phone = house.phone;
    modelBase.contact = house.contact;
    modelBase.touristPointId = house.touristPointId;
    modelBase.images = this.imagesNames;
    return modelBase;
  }
  private getBy(houseResponse: HouseDetailInfo) {
    this.house = houseResponse;
    this.imagesNames = this.house.images ? this.house.images.map(image => this.sourceImage + '/' + image.name)
      : [];
    var touristPoint = this.touristPoints.find(x => x.id == this.house.touristPointId);
    this.touristPointName = touristPoint.name;
  }
  private getAllTouristPoints(touristPointResponse: TouristPointsBasicInfo[]) {
    this.touristPoints = touristPointResponse;
  }
  private showError(message: string) {
    this.errorBackend = message;
  }
  onChangeTouristPointName(touristPointName: string) {

    var touristPoint = this.touristPoints.find(x => x.name == touristPointName);
    this.house.touristPointId = touristPoint.id;
  }


  selectFiles(event) {
    this.selectedFiles = event.target.files;
    for (let i = 0; i < this.selectedFiles.length; i++) {
      this.imagesNames.push(this.selectedFiles[i].name);
    }
  }

}
