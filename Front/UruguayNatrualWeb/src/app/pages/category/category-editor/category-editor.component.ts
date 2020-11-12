import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CategoryBasicInfo } from 'src/app/models/category/category-basic-info';
import { CategoryDetailInfo } from 'src/app/models/category/category-detail-info';
import { TouristPointsBasicInfo } from 'src/app/models/touristpoint/touristpoint-base-info';
import { CategoryService } from 'src/app/services/categories/category.service';
import { TouristPointsService } from 'src/app/services/touristpoints/touristpoint.service';

const newLocal = false;
@Component({
  selector: 'app-category-editor',
  templateUrl: './category-editor.component.html',
  styleUrls: ['./category-editor.component.css']
})
export class CategoryEditorComponent implements OnInit {
  public category: CategoryDetailInfo = {} as CategoryDetailInfo;
  public touristPoints: TouristPointsBasicInfo[] = [];
  public categoryId: number = 0;
  public touristPointName: string[] = [];
  public newTouristPoint:  TouristPointsBasicInfo = {} as TouristPointsBasicInfo;
  public existentCategory: boolean = false;
  constructor(
    private route: ActivatedRoute,
    private categoryService: CategoryService,
    private touristPointService: TouristPointsService) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.categoryId = Number(id);
    this.existentCategory = this.isExistentCategory();
    this.categoryService.getBy(this.categoryId).subscribe(
      categoryResponse =>
        this.getBy(categoryResponse), (error: string) => this.showError(error));
        this.touristPointService.getAll().subscribe(
      touristPointResponse =>
      this.getAllTouristPoints(touristPointResponse), (error: string) =>this.showError(error));

   }

  private isExistentCategory(): boolean
  {
    var existCategory = false;
    if (this.categoryId != 0)
    {
      existCategory = true;
    }
     return existCategory;
  }
  private getBy(categoryResponse: CategoryDetailInfo){
    this.category = categoryResponse;
    this.touristPointName = this.category.touristPoints? this.category.touristPoints.map(touristPonit => touristPonit.name)
      : [];
  }

  private getAllTouristPoints(touristPointResponse: TouristPointsBasicInfo[]){
    this.touristPoints = touristPointResponse;
  }


  updateData(category : CategoryDetailInfo){
    const basicInfo = this.createModel(category);
    this.categoryService.update(this.categoryId, basicInfo).subscribe(
      responseUpdate =>
        console.log(responseUpdate)
    );
  }

  private createModel(category : CategoryDetailInfo) : CategoryBasicInfo{
    const modelBase : CategoryBasicInfo = {} as CategoryBasicInfo;
    modelBase.name = category.name;
    modelBase.touristPoints = category.touristPoints.map(x=> x.id);
    return modelBase;
  }

  onChangeTouristPointName(touristPointName: string, index: number){

    const touristPointId = this.touristPoints.find(x => x.name == touristPointName);
    this.category.touristPoints[index] = touristPointId;
  }

  addTouristPoint(){
    if(this.category.touristPoints[this.category.touristPoints.length-1].id == null){
      console.log('NO ADDED WITH ONE EMPTY');
    } else {
      this.category.touristPoints = this.category.touristPoints.concat(this.newTouristPoint);
    }
  }
  deleteTouristPoint(){
    this.category.touristPoints.pop();
  }

  private showError(message: string){
    console.log(message);
  }
}
