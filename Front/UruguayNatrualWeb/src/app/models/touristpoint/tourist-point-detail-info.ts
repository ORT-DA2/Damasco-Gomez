import { CateogryBasicInfo } from "../category/category-basic-info";
import { ImageTouristPointBasic } from "../imagetouristpoint/Imagetourispoint-base-info";
import { RegionBasicInfo } from "../regions/region-base-info";

export interface TouristPointDetailInfo {
  id : number,
  name : string,
  image : ImageTouristPointBasic,
  decsription : string,
  regionId : number,
  region : RegionBasicInfo,
  categories : CateogryBasicInfo[],
}
