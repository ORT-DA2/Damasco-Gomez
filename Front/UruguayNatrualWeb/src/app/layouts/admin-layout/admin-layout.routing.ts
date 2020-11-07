import { Routes } from '@angular/router';

import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { IconsComponent } from '../../pages/icons/icons.component';
import { UserProfileComponent } from '../../pages/user-profile/user-profile.component';
import { TablesComponent } from '../../pages/tables/tables.component';
import { BookingDashboardComponent } from 'src/app/pages/booking/booking-dashboard/booking-dashboard.component';
import { BookingEditorComponent } from 'src/app/pages/booking/booking-editor/booking-editor.component';
import { TouristPointDashboardComponent } from 'src/app/pages/tourist-point/tourist-point-dashboard/tourist-point-dashboard.component';
import { TouristPointEditorComponent } from 'src/app/pages/tourist-point/tourist-point-editor/tourist-point-editor.component';
import { CategoryDashboardComponent } from 'src/app/pages/category/category-dashboard/category-dashboard.component';

export const AdminLayoutRoutes: Routes = [
    { path: 'dashboard',      component: DashboardComponent },
    { path: 'user-profile',   component: UserProfileComponent },
    { path: 'tables',         component: TablesComponent },
    { path: 'icons',          component: IconsComponent },
    { path: 'bookings',       component: BookingDashboardComponent },
    { path: 'bookings/booking-editor/:id',       component: BookingEditorComponent },
    { path: 'tourist-points',       component: TouristPointDashboardComponent },
    { path: 'tourist-points/tourist-point-editor/:id',       component: TouristPointEditorComponent },
    { path: 'categories',       component: CategoryDashboardComponent },
];
