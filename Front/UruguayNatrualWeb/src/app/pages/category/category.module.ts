import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoryTableComponent } from './category-table/category-table.component';
import { CategoryDashboardComponent } from './category-dashboard/category-dashboard.component';
import { CategoryEditorComponent } from './category-editor/category-editor.component';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { CategoryEditorNewComponent } from './category-editor-new/category-editor-new.component';

@NgModule({
  imports: [
    CommonModule,
    CategoryModule,
    ReactiveFormsModule,
    BrowserModule,
  ],
  declarations: [
    CategoryTableComponent,
    CategoryDashboardComponent,
    CategoryEditorComponent,
    CategoryEditorNewComponent
  ],
  providers: [],
})
export class CategoryModule { }
