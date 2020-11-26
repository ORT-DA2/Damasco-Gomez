import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { catchError } from 'rxjs/operators';
import { PersonBasicInfo } from 'src/app/models/person/person-base-info';
import { PersonService } from 'src/app/services/persons/person.service';

@Component({
  selector: 'app-admin-editor',
  templateUrl: './admin-editor.component.html',
  styleUrls: ['./admin-editor.component.css']
})
export class AdminEditorComponent implements OnInit {
  public person: PersonBasicInfo = {} as PersonBasicInfo;
  public existPerson: boolean;
  public personId: number;
  public errorMessageEndpoint: string = '';
  public updateMessage: string = '';

  constructor(
    private route: ActivatedRoute, private personService: PersonService) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.personId = Number(id);
    this.existPerson = !this.idNan(this.personId);
    if (this.existPerson){
      this.personService.getBy(this.personId)
      .subscribe( response => {this.person = response;}, catchError => {});
    }
  }

  idNan(num: number){
    return isNaN(num);
  }

  update(): void {
    this.personService.update(this.personId, this.person)
    .subscribe(response => {
      this.person = response;
      this.updateMessage = 'Update!';
      this.errorMessageEndpoint = '';},
    catchError => {
      this.errorMessageEndpoint = catchError + ', fix it and try again'})
  }
  add(): void{
    this.personService.newUser(this.person)
    .subscribe(response=> {
      this.updateMessage = 'Added!';
      this.person = response;
      this.errorMessageEndpoint = '';
    },
    catchError => {
      this.errorMessageEndpoint = catchError + ', fix it and try again'
    })
  }
}
