import {ImageTouristPointBasic} from './app/models/imagetouristpoint/imagetouristpoint-base-info';

export interface TouristPointsBasicInfo {
  id : number,
  name : string,
  image : ImageTouristPointBasic,
  decsription : string,
  regionId : number,

}
