import { Component, OnInit } from '@angular/core';
import { PersonBasicInfo } from 'src/app/models/person/person-base-info';
import { PersonService } from 'src/app/services/persons/person.service';

@Component({
  selector: 'app-admin-table',
  templateUrl: './admin-table.component.html',
  styleUrls: ['./admin-table.component.css']
})
export class AdminTableComponent implements OnInit {
  public persons: PersonBasicInfo[] = [];
  public errorMessageEndpoint: string = '';

  constructor(private personService: PersonService) { }

  ngOnInit(): void {
    this.personService.getAll()
    .subscribe(
      response => {this.getAll(response)},
      catchError => {this.errorMessageEndpoint = catchError}
    );
  }

  private getAll(personResponse: PersonBasicInfo[]){
    this.persons = personResponse;
  }

  delete(person: PersonBasicInfo){
    this.personService.delete(person.id)
    .subscribe( response => {
      this.delete(response);
      this.persons = this.persons.filter(item => item.id != person.id);
      this.errorMessageEndpoint = '';
    },
    catchError => {
      this.errorMessageEndpoint = catchError.error;
    })
  }

}
