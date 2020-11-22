import { ImageBasicModel } from "../image-house/image-house.-basic";
import { TouristPointsBasicInfo } from "../touristpoint/touristpoint-base-info";

export interface HouseDetailInfo {
  id : number,
  avaible : boolean,
  pricePerNight : number,
  touristPointId : number,
  name : string,
  starts : number,
  address : string,
  images : ImageBasicModel [],
  description : string,
  phone : number,
  contact: string,
  totalPrice: number,
  touristPoint :  TouristPointsBasicInfo ,

}






