import { Component, OnInit, OnDestroy } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { PersonBasicInfo } from 'src/app/models/person/person-base-info';
import { PersonService } from 'src/app/services/persons/person.service';
import { SessionService } from 'src/app/services/sessions/session.service';
import Swal from 'sweetalert2';
import { SessionUserModel } from '../../models/sessions/session-user-model';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public errorMessageEndpoint: string = '';
  private persons : PersonBasicInfo[];

  constructor(private sessionService: SessionService, private personService: PersonService,
    private router: Router) { }

  sessionUser: SessionUserModel = new SessionUserModel();

  ngOnInit() {
    this.personService.getAll().subscribe(
      response => this.persons = response
    )
  }

  login(form: NgForm) {
    this.sessionService.login(this.sessionUser).
      subscribe(
        response => {
          localStorage.setItem('email', this.sessionUser.email);
          localStorage.setItem('name', this.findName(this.sessionUser.email).name);
          this.router.navigateByUrl('/user-profile');
        },
        catchError => {
          this.errorMessageEndpoint = catchError.error + ', fix it and try again';
        }
      )
  }

  findName(email:string){
    return this.persons.find(x => x.email === email);
  }

}
