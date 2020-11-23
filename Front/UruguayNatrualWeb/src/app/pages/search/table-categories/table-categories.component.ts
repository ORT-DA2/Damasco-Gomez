import { Component, OnInit } from '@angular/core';
import { CategoryBasicInfo } from 'src/app/models/category/category-basic-info';
import { CategoryService } from 'src/app/services/categories/category.service';

@Component({
  selector: 'app-table-categories',
  templateUrl: './table-categories.component.html',
  styleUrls: ['./table-categories.component.css']
})
export class TableCategoriesComponent implements OnInit {
  public categories: CategoryBasicInfo[] = [];
  public errorMessageBackend: string = '';

  constructor(private categoryService: CategoryService) { }

  ngOnInit(): void {
    this.categoryService.getAll().subscribe(
      categoryResponse =>
        this.getAll(categoryResponse), (error: string) => this.showError(error)
    );
  }
  private getAll(categoryResponse: CategoryBasicInfo[]){
    this.categories = categoryResponse;
  }

  private showError(message: string){
    this.errorMessageBackend = message;
  }

}
