import { CategoryBasicInfo } from "../category/category-basic-info";
import { ImageTouristPointBasic } from "../imagetouristpoint/Imagetourispoint-base-info";
import { RegionBasicInfo } from "../regions/region-base-info";

export interface TouristPointDetailInfo {
  id : number,
  name : string,
  image : ImageTouristPointBasic,
  description : string,
  regionId : number,
  region : RegionBasicInfo,
  categories : CategoryBasicInfo[],
}
