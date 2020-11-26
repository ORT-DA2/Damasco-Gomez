import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';
import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { AdminGuard } from './guards/admin.guard';
import { TouristLayoutComponent } from './layouts/tourist-layout/tourist-layout.component';

const routes: Routes =[
  {
    path: '',
    redirectTo: 'search',
    pathMatch: 'full',
  }, {
    path: '',
    component: AdminLayoutComponent, canActivate: [AdminGuard],
    children: [
      {
        path: '',
        loadChildren: './layouts/admin-layout/admin-layout.module#AdminLayoutModule'
      }
    ]
  }, {
    path: '',
    component: TouristLayoutComponent,
    children: [
      {
        path: '',
        loadChildren: './layouts/tourist-layout/tourist-layout.module#TouristLayoutModule'
      }
    ]
  }, {
    path: '**',
    redirectTo: 'login'
  }
];

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
  ],
})
export class AppRoutingModule { }
