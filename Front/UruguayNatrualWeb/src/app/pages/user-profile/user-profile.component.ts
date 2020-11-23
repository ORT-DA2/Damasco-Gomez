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
  public id: Number = 0;
  public errorMessageBackend: string = '';
  public email : string = '';
  public updateMessage: string = '';

  constructor(private userService: PersonService) { }

  ngOnInit() {
    this.email = localStorage.getItem('email');
    this.userService.getAll().subscribe(
      personResponse =>
        this.getAll(personResponse), (error: string) => this.showError(error)
    );
  }

  updateData() {
    const basicInfo = this.createModel(this.user);
    this.userService.update(this.user.id, basicInfo).subscribe(
      responseUpdate => console.log(responseUpdate)// this.updateMessage = 'Update sucessfully!'
    );
  }

  private createModel(user: PersonBasicInfo): PersonBasicInfo {
    const modelBase: PersonBasicInfo = {} as PersonBasicInfo;
    modelBase.name = user.name;
    modelBase.email = user.email;
    modelBase.password = user.password;
    return modelBase;
  }

  private getAll(personResponse: PersonBasicInfo[]){
    this.user = personResponse.find( x => x.email == this.email);
  }

  private showError(message: string){
    this.errorMessageBackend = message;
  }
}
