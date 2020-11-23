import { Component, OnInit } from '@angular/core';
import { BookingDetailInfo } from 'src/app/models/booking/booking-detail-info';
import { BookingService } from 'src/app/services/bookings/booking.service';
import { ActivatedRoute } from '@angular/router';
import { HouseBasicInfo } from 'src/app/models/house/house-base-info';
import { HouseService } from 'src/app/services/houses/house.service';
import { StatesService } from 'src/app/services/states/states.service';
import { StateBasicInfo } from 'src/app/models/state/state-base-info';

@Component({
  selector: 'app-booking-editor',
  templateUrl: './booking-editor.component.html',
  styleUrls: ['./booking-editor.component.css']
})
export class BookingEditorComponent implements OnInit {
  public booking: BookingDetailInfo = {} as BookingDetailInfo;
  public houses: HouseBasicInfo[] = [];
  public states: StateBasicInfo[] = [];
  public bookingId: number = 0;
  public errorBackend: string = '';

  constructor(
    private route: ActivatedRoute,
    private bookingService: BookingService,
    private houseService: HouseService,
    private stateService: StatesService) { }


  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.bookingId = Number(id);
    this.bookingService.getBy(this.bookingId).subscribe(
      bookingResponse =>
        this.getBy(bookingResponse), (error: string) => this.showError(error));
    this.houseService.getAll().subscribe(
      houseResponse =>
        this.getAllHouses(houseResponse), (error: string) =>this.showError(error));
    this.stateService.getAll().subscribe(
      stateResponse =>
        this.getAllStates(stateResponse), (error: string) =>this.showError(error));
  }

  private getBy(bookingResponse: BookingDetailInfo){
    this.booking = bookingResponse;
  }
  private getAllHouses(houseResponse: HouseBasicInfo[]){
    this.houses = houseResponse;
  }
  private getAllStates(stateResponse: StateBasicInfo[]){
    this.states = stateResponse;
  }

  private showError(message: string){
    this.errorBackend = message;
  }

}
