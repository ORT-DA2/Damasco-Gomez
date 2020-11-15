import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { HouseBasicInfo } from 'src/app/models/house/house-base-info';
import { HouseService } from 'src/app/services/houses/house.service';

@Component({
  selector: 'app-house-search',
  templateUrl: './house-search.component.html',
  styleUrls: ['./house-search.component.css']
})
export class HouseSearchComponent implements OnInit {
  panelOpenState = false;
  public houses: HouseBasicInfo[] = {} as HouseBasicInfo[];
  touristPointId: string;
  public checkIn: string;
  public checkOut: string;
  checkInValue: string = '11/11/2020';
  checkOutValue: string = '12/12/2020';
  public cantAdults: string = '1';
  public cantChildren: string = '0';
  public cantBabies: string = '0';
  public cantSeniors: string = '0';
  public searchDone: boolean = false;

  public myForm: FormGroup;
  closeResult: string;

  constructor(
    private route: ActivatedRoute,
    private houseService: HouseService,
    private modalService: NgbModal) { }

  ngOnInit(): void {
    this.touristPointId = (this.route.snapshot.paramMap.get('id'));
  }

  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return  `with: ${reason}`;
    }
  }

  private getAll(houseResponse: HouseBasicInfo[]) {
    this.houses = houseResponse;
    this.searchDone = true;
  }

  private showError(message: string) {
    console.log(message);
  }

  searchBy() {
    this.houseService.getByTouristoPoint(this.checkInValue, this.checkOutValue, this.touristPointId,
      this.cantAdults, this.cantChildren, this.cantBabies, this.cantSeniors).subscribe(
        houseResponse =>
          this.getAll(houseResponse), (error: string) => this.showError(error)
      );
  }

  onChangeCheckIn(event) {
    this.checkInValue = this.parseDate(event);
  }
  onChangeCheckOut(event) {
    this.checkOutValue = this.parseDate(event);
  }

  private parseDate(date: string) {
    var dates = date.split('-');
    const year = dates.length == 3 ? dates[0] : '0';
    const month = dates.length == 3 ? dates[1] : '0';
    const day = dates.length == 3 ? dates[2] : '0';
    return day + '/' + month + '/' + year;
  }

  chooseHouse(house) {
    console.log(house)
  }
}
