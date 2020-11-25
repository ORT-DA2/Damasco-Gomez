import { Component, OnInit } from '@angular/core';
import { RegionBasicInfo } from 'src/app/models/regions/region-base-info';
import { RegionService } from 'src/app/services/regions/region.service';

@Component({
  selector: 'app-table-regions',
  templateUrl: './table-regions.component.html',
  styleUrls: ['./table-regions.component.css']
})
export class TableRegionsComponent implements OnInit {
  public regions: RegionBasicInfo[] = [];
  public errorMessageBackend: string = '';

  constructor(private regionService: RegionService) {

  }

  ngOnInit(): void {
    this.regionService.getAll()
    .subscribe(
      regionResponse => {
        this.getAll(regionResponse);
      },
      catchError => {
        this.errorMessageBackend = catchError.error + ', fix it and try again';
      }
    );
  }
  private getAll(regionResponse: RegionBasicInfo[]){
    this.regions = regionResponse;
  }
}
