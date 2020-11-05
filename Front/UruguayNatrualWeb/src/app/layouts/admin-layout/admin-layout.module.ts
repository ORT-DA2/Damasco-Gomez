import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ClipboardModule } from 'ngx-clipboard';

import { AdminLayoutRoutes } from './admin-layout.routing';
import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { IconsComponent } from '../../pages/icons/icons.component';
import { UserProfileComponent } from '../../pages/user-profile/user-profile.component';
import { TablesComponent } from '../../pages/tables/tables.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BookingsTableComponent } from 'src/app/pages/booking/bookings-table/bookings-table.component';
import { BookingDashboardComponent } from 'src/app/pages/booking/booking-dashboard/booking-dashboard.component';
import { TouristPointDashboardComponent } from 'src/app/pages/tourist-point/tourist-point-dashboard/tourist-point-dashboard.component';
import { TouristPointsTableComponent } from 'src/app/pages/tourist-point/tourist-points-table/tourist-points-table.component';
import { BookingEditorComponent } from 'src/app/pages/booking/booking-editor/booking-editor.component';
import { TouristPointEditorComponent } from 'src/app/pages/tourist-point/tourist-point-editor/tourist-point-editor.component';
// import { ToastrModule } from 'ngx-toastr';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AdminLayoutRoutes),
    FormsModule,
    HttpClientModule,
    NgbModule,
    ClipboardModule
  ],
  declarations: [
    DashboardComponent,
    UserProfileComponent,
    TablesComponent,
    IconsComponent,
    BookingsTableComponent,
    BookingDashboardComponent,
    BookingEditorComponent,
    TouristPointDashboardComponent,
    TouristPointsTableComponent,
    TouristPointEditorComponent,
  ]
})

export class AdminLayoutModule {}
