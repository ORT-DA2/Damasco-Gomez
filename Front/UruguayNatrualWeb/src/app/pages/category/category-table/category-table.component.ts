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
  constructor(private categoryService: CategoryService) { }


  ngOnInit(): void {
    this.categoryService.getAll().subscribe(
      response =>
        this.getAll(response), (error: string) => this.showError(error)
    );
  }

  private getAll(response: CategoryBasicInfo[]){
    this.categories = response;
  }

  private showError(message: string){
    console.log(message);
  }


}
