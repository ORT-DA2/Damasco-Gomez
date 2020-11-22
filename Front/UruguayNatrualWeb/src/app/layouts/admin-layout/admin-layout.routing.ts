import { Routes } from '@angular/router';

import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { UserProfileComponent } from '../../pages/user-profile/user-profile.component';
import { TablesComponent } from '../../pages/tables/tables.component';
import { BookingDashboardComponent } from 'src/app/pages/booking/booking-dashboard/booking-dashboard.component';
import { BookingEditorComponent } from 'src/app/pages/booking/booking-editor/booking-editor.component';
import { TouristPointDashboardComponent } from 'src/app/pages/tourist-point/tourist-point-dashboard/tourist-point-dashboard.component';
import { TouristPointEditorComponent } from 'src/app/pages/tourist-point/tourist-point-editor/tourist-point-editor.component';
import { CategoryDashboardComponent } from 'src/app/pages/category/category-dashboard/category-dashboard.component';
import { CategoryEditorComponent } from 'src/app/pages/category/category-editor/category-editor.component';
import { HouseEditorComponent } from 'src/app/pages/house/house-editor/house-editor.component';
import { HouseDashboardComponent } from 'src/app/pages/house/house-dashboard/house-dashboard.component';
import { ReportDashboardComponent } from 'src/app/pages/report/report-dashboard/report-dashboard.component';




export const AdminLayoutRoutes: Routes = [
    { path: 'dashboard',      component: DashboardComponent },
    { path: 'user-profile',   component: UserProfileComponent },
    { path: 'bookings',       component: BookingDashboardComponent },
    { path: 'bookings/booking-editor/:id',       component: BookingEditorComponent },
    { path: 'tourist-points',       component: TouristPointDashboardComponent },
    { path: 'tourist-points/tourist-point-editor/:id',       component: TouristPointEditorComponent },
    { path: 'categories',       component: CategoryDashboardComponent },
    { path : 'category/category-editor/:id', component :  CategoryEditorComponent},
    { path : 'house/house-editor/:id', component :  HouseEditorComponent},
    { path: 'houses',       component: HouseDashboardComponent },
    { path: 'reports',       component: ReportDashboardComponent },



];
