import { Routes } from '@angular/router';

import { UserProfileComponent } from '../../pages/user-profile/user-profile.component';
import { BookingDashboardComponent } from 'src/app/pages/booking/booking-dashboard/booking-dashboard.component';
import { BookingEditorComponent } from 'src/app/pages/booking/booking-editor/booking-editor.component';
import { TouristPointDashboardComponent } from 'src/app/pages/tourist-point/tourist-point-dashboard/tourist-point-dashboard.component';
import { TouristPointEditorComponent } from 'src/app/pages/tourist-point/tourist-point-editor/tourist-point-editor.component';
import { CategoryDashboardComponent } from 'src/app/pages/category/category-dashboard/category-dashboard.component';
import { CategoryEditorComponent } from 'src/app/pages/category/category-editor/category-editor.component';
import { HouseEditorComponent } from 'src/app/pages/house/house-editor/house-editor.component';
import { HouseDashboardComponent } from 'src/app/pages/house/house-dashboard/house-dashboard.component';
import { ReportDashboardComponent } from 'src/app/pages/report/report-dashboard/report-dashboard.component';
import { ImportDashboardComponent } from 'src/app/pages/import/import-dashboard/import-dashboard.component';
import { AdminDashboardComponent } from 'src/app/pages/admin/admin-dashboard/admin-dashboard.component';
import { AdminEditorComponent } from 'src/app/pages/admin/admin-editor/admin-editor.component';




export const AdminLayoutRoutes: Routes = [
  { path: 'user-profile', component: UserProfileComponent },
  {
    path: 'bookings',
    children: [
      { path: '', component: BookingDashboardComponent },
      { path: 'booking-editor/:id', component: BookingEditorComponent }
    ]
  },
  {
    path: 'tourist-points',
    children: [
      { path: '', component: TouristPointDashboardComponent },
      { path: 'tourist-point-editor/:id', component: TouristPointEditorComponent },
    ]
  },
  {
    path: 'categories',
    children: [
      { path: '', component: CategoryDashboardComponent },
      { path: 'category-editor/:id', component: CategoryEditorComponent },
    ]
  },
  {
    path: 'houses', children: [
      { path: '', component: HouseDashboardComponent },
      { path: 'house-editor/:id', component: HouseEditorComponent },
    ]
  },
  { path: 'reports', component: ReportDashboardComponent },
  { path: 'import', component: ImportDashboardComponent },
  {
    path: 'admin',
    children: [
      { path: '', component: AdminDashboardComponent },
      { path: 'admin-editor/:id', component: AdminEditorComponent },
    ]
  },
];
