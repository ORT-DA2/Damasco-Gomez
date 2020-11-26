import { ImageHouseBasicModel } from "../image-house/image-house-basic";
import { ReviewBasicInfo } from "../reviews/review-base-info";

export interface HouseBasicInfo {
  id : number,
  avaible : boolean,
  pricePerNight : number,
  touristPointId : number,
  name : string,
  starts : number,
  address : string,
  imagesSource: string[],
  images : ImageHouseBasicModel [],
  description : string,
  phone : number,
  contact: string,
  totalPrice: number,
  reviews: ReviewBasicInfo[];
}
