import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

import { AppComponent } from './app.component';
import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app.routing';
import { ComponentsModule } from './components/components.module';
import { TouristPointsService } from './services/touristpoints/touristpoint.service';
import { CategoryService } from './services/categories/category.service';
import { BookingService } from './services/bookings/booking.service';
import { HouseService } from './services/houses/house.service';
import { PersonService } from './services/persons/person.service';
import { RegionService } from './services/regions/region.service';
import { ReportService } from './services/reports/report.service';
import { ReviewService } from './services/reviews/review.service';
import { SessionService } from './services/sessions/session.service';
import { TouristLayoutComponent } from './layouts/tourist-layout/tourist-layout.component';
import { ImportDashboardComponent } from './pages/import/import-dashboard/import-dashboard.component';





@NgModule({
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    ComponentsModule,
    NgbModule,
    RouterModule,
    AppRoutingModule,
    ReactiveFormsModule,
    RouterModule,
    FormsModule,
  ],
  declarations: [
    AppComponent,
    AdminLayoutComponent,
    TouristLayoutComponent,
    ImportDashboardComponent,
  ],
  providers: [TouristPointsService,
    CategoryService,
    BookingService,
    HouseService,
    PersonService,
    RegionService,
    ReportService,
    ReviewService,
    HouseService,
    SessionService],
  bootstrap: [AppComponent]
})
export class AppModule { }
