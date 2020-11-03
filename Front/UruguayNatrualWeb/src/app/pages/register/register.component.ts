import { Component, OnInit } from '@angular/core';
import {SessionUserModel} from '../../models/sessions/session-user-model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  sessionUser: SessionUserModel;

  constructor() { }

  ngOnInit() {
    this.sessionUser = new SessionUserModel ();
    this.sessionUser.email = 'yulianagomezsilva@gmail.com';
  }
  onSubmit()
  {
    console.log('formulario creado');
    console.log(this.sessionUser);
  }

}
