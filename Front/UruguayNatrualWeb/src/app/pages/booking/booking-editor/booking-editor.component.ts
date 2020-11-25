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
  public dateIn: string = '';
  public dateOut: string = '';
  public errorMessageEndpoint: string = '';
  public stateName: string = '';
  public updateMessage: string = '';

  constructor(
    private route: ActivatedRoute,
    private bookingService: BookingService,
    private houseService: HouseService,
    private stateService: StatesService) { }


  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.bookingId = Number(id);
    this.bookingService.getBy(this.bookingId)
    .subscribe(
      bookingResponse => {
        this.getBy(bookingResponse);
        this.dateIn = this.formatDate(this.booking.checkIn);
        this.dateOut = this.formatDate(this.booking.checkOut);
        this.stateName = bookingResponse.state.name;
      },
      catchError => {
        this.errorMessageEndpoint = catchError.error + ', fix it and try again';
      }
    );
    this.houseService.getAll()
    .subscribe(
      houseResponse => {
        this.getAllHouses(houseResponse)
      },
      catchError => {
        this.errorMessageEndpoint = catchError.error + ', fix it and try again';
      }
    );
    this.stateService.getAll()
    .subscribe(
      stateResponse => {
        this.getAllStates(stateResponse)
      },
      catchError => {
        this.errorMessageEndpoint = catchError.error + ', fix it and try again';
      }
    );
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

  formatDate(date: Date){
    var dateString = date.toString();
    var dateArray = dateString.split('-');
    if(dateArray.length == 3){
      const year = dateArray[0];
      const month = dateArray[1];
      const day = dateArray[2].substr(0,2);
      return year + '-' + month + '-' + day;
    }
    return '';
  }

  onChangeStateName(stateName: string){
    const newStateId = this.states.filter(s => s.name === stateName);
    this.booking.stateId = newStateId[0].id;
  }

  updateState(){
    this.bookingService.update(this.bookingId,this.booking)
    .subscribe(
      bookingResponse => {
        this.updateMessage = 'Update done!';
      },
      catchError => {
        this.errorMessageEndpoint = catchError.error + ', fix it and try again';
      }
    );
  }
}
