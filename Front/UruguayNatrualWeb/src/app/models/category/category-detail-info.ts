import { TouristPointsBasicInfo } from '../touristpoint/touristpoint-base-info';

export interface CategoryDetailInfo {
id: number,
name: string;
touristPoints: TouristPointsBasicInfo[],

}
