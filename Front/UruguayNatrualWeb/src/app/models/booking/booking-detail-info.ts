import { HouseBasicInfo } from "../house/house-base-info";
import { StateBasicInfo } from "../state/state-base-info";

export interface BookingDetailInfo{
  id : number;
  name : string;
  email : string;
  code : string;
  houseId : number;
  house : HouseBasicInfo;
  stateId : number;
  state : StateBasicInfo;
  price : number;
  checkIn : Date;
  checkOut : Date;
}
