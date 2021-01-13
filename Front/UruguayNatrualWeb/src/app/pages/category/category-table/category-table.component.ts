import { Component, OnInit } from '@angular/core';
import { CategoryBasicInfo } from 'src/app/models/category/category-basic-info';
import { CategoryService } from 'src/app/services/categories/category.service';

@Component({
  selector: 'app-category-table',
  templateUrl: './category-table.component.html',
  styleUrls: ['./category-table.component.css']
})
export class CategoryTableComponent implements OnInit {
  public categories: CategoryBasicInfo[] = [];
  public id: Number = 0;
  public errorBackend: string = '';

  constructor(private categoryService: CategoryService) { }


  ngOnInit(): void {
    this.categoryService.getAll()
    .subscribe(
      response => {
        this.getAll(response)
      },
      catchError => {
        this.errorBackend = catchError + ', fix it and try again';
      }
    );
  }

  private getAll(response: CategoryBasicInfo[]){
    this.categories = response;
  }

  delete(event) {
    this.id = event.id;
    this.categoryService.delete(this.id)
    .subscribe(
      response => {
        this.categories = this.categories.filter(item => item.id != this.id);
      },
      catchError => {
        this.errorBackend = catchError + ', fix it and try again';
      }
    );
  }

}
