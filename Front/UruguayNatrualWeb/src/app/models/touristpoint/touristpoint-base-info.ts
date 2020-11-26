
import { CategoryBasicInfo } from "../category/category-basic-info";
import { ImageTouristPointBasic } from "../imagetouristpoint/Imagetourispoint-base-info";
import { RegionBasicInfo } from "../regions/region-base-info";

export interface TouristPointsBasicInfo {
  id : number,
  name : string,
  image : ImageTouristPointBasic,
  categories : number[],
  description : string,
  regionId : number,
  region : RegionBasicInfo,

}
