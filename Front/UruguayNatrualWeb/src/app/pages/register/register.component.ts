import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { PersonBasicInfo } from 'src/app/models/person/person-base-info';
import { PersonService } from '../../services/persons/person.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  public user: PersonBasicInfo = {} as PersonBasicInfo;

  constructor(private personService: PersonService) { }

  ngOnInit() {
  }

  onSubmit(form: NgForm) {
    if (form.invalid) {return; }
    this.personService.newUser(this.user).
      subscribe(resp => {
          console.log(resp);
        });
  }

}
