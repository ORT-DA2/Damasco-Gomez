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

  public user: PersonBasicInfo = {} as PersonBasicInfo;


  constructor(private personService: PersonService,
              private sessionService: SessionService,
              private router: Router ) { }

  ngOnInit() {
  }

  onSubmit(form: NgForm) {
    if (form.invalid) {return; }
   this.personService.newUser(this.user).
   subscribe(resp => {
    this.loginNewUser(resp);
   });
  }

  loginNewUser (user: any)
  {
      this.sessionService.login(this.user).
      subscribe(resp => {
      this.router.navigateByUrl('/dashboard');
      });
  }

}
