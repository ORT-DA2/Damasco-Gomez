import { Component, OnInit } from '@angular/core';
import { PersonBasicInfo } from 'src/app/models/person/person-base-info';
import { PersonService } from 'src/app/services/persons/person.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfileComponent implements OnInit {
  public user: PersonBasicInfo = {} as PersonBasicInfo;
  public persons: PersonBasicInfo[] = [];
  public id: Number = 0;
  public errorMessageBackend: string = '';
  public email : string = '';
  public updateMessage: string = '';
  public errorMessageEndpoint:string = '';

  constructor(private userService: PersonService) { }

  ngOnInit() {
    this.email = localStorage.getItem('email');
    this.userService.getAll()
    .subscribe(
      personResponse => {
        this.persons = personResponse;
        this.getPersonWithMail();
        localStorage.setItem('name',this.user.name);
      },
      catchError => {
        this.errorMessageEndpoint = catchError.error + ', fix it and try again';
      }
    );
  }

  updateData() {
    const basicInfo = this.createModel(this.user);
    this.userService.update(this.user.id, basicInfo)
    .subscribe(
      personResponse => {
        this.user = personResponse;
        localStorage.setItem('name',this.user.name);
        this.updateMessage = 'Update sucessfully!'
      },
      catchError => {
        this.errorMessageEndpoint = catchError.error + ', fix it and try again';
      }
    );
  }

  private createModel(user: PersonBasicInfo): PersonBasicInfo {
    const modelBase: PersonBasicInfo = {} as PersonBasicInfo;
    modelBase.name = user.name;
    modelBase.email = user.email;
    modelBase.password = user.password;
    return modelBase;
  }

  private getPersonWithMail(){
    this.user = this.persons.find( x => x.email == this.email);
  }
}
