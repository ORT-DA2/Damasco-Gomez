export interface BookingBasicInfo {
  id : number;
  name : string;
  email : string;
  code : string;
  houseId : number;
  stateId : number;
  price : number;
  checkIn : Date;
  checkOut : Date;
}
