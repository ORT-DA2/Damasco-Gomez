import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CategoryBasicInfo } from 'src/app/models/category/category-basic-info';
import { CategoryDetailInfo } from 'src/app/models/category/category-detail-info';
import { TouristPointsBasicInfo } from 'src/app/models/touristpoint/touristpoint-base-info';
import { CategoryService } from 'src/app/services/categories/category.service';
import { TouristPointsService } from 'src/app/services/touristpoints/touristpoint.service';

@Component({
  selector: 'app-category-editor',
  templateUrl: './category-editor.component.html',
  styleUrls: ['./category-editor.component.css']
})
export class CategoryEditorComponent implements OnInit {
  public category: CategoryDetailInfo = {} as CategoryDetailInfo;
  public touristPoints: TouristPointsBasicInfo[] = [];
  public categoryId: number = 0;
  tourisPointNew: TouristPointsBasicInfo = {} as TouristPointsBasicInfo;

  constructor(
    private route: ActivatedRoute,
    private categoryService: CategoryService,
    private touristPointService: TouristPointsService) { }

  ngOnInit(): void {
  }

}
