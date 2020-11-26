import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { PersonBasicInfo } from 'src/app/models/person/person-base-info';
import { SessionService } from 'src/app/services/sessions/session.service';
import { PersonService } from '../../services/persons/person.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  public errorMessageEndpoint: string = '';

  public user: PersonBasicInfo = {} as PersonBasicInfo;


  constructor(private personService: PersonService,
    private sessionService: SessionService,
    private router: Router) { }

  ngOnInit() {
  }

  createAccount() {
    this.personService.newUser(this.user).
      subscribe(
        response => {
          console.log(response);
          localStorage.setItem('name',response.name);
          localStorage.setItem('email',response.email);
          this.loginNewUser(response);
        },
        catchError => {
          this.errorMessageEndpoint = catchError.error + ', fix it and try again';
        }
      )
  }

  loginNewUser(user: any) {
    this.sessionService.login(this.user).
    subscribe(
      response => {
        this.router.navigateByUrl('/user-profile');
      },
      catchError => {
        this.errorMessageEndpoint = catchError.error + ', fix it and try again';
      }
    )
  }

}
