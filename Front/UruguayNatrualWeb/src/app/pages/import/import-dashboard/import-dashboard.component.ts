import { Component, OnInit } from '@angular/core';
import { ImportBasicInfo } from 'src/app/models/import/import-basic-info';
import { ImportService } from 'src/app/services/import/import.service';

@Component({
  selector: 'app-import-dashboard',
  templateUrl: './import-dashboard.component.html',
  styleUrls: ['./import-dashboard.component.css']
})
export class ImportDashboardComponent implements OnInit {
  fileInfo: ImportBasicInfo = {} as ImportBasicInfo;
  public errorMessageBackend: string = '';
  public updateMessage: string = '';

  constructor(private importService: ImportService) { }

  ngOnInit(): void {
  }

  onSelectFile(event){
    const fileName = event.target.files[0] ? event.target.files[0] : '';
    this.fileInfo.path = './Parser/' + fileName.name;
  }

  importData() {
    this.importService.post(this.fileInfo)
      .subscribe(
        responseResponse => {
          console.log(responseResponse);
          this.errorMessageBackend = '';
          this.updateMessage = 'Added!'
        },
        catchError => {
          debugger;
          this.errorMessageBackend = catchError + ', fix it and try again';
        }
      );
  }
}
