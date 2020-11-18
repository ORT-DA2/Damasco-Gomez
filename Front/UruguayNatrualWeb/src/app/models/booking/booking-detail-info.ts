export interface BookingDetailInfo{
  id : number;
  name : string;
  email : string;
  code : string;
  houseId : number;
  // house : HouseBasicInfo;
  stateId : number;
  // state : StateBasicInfo;
  price : number;
  checkIn : Date;
  checkOut : Date;
}
