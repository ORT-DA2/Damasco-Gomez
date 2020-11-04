import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
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
  }
  onSubmit(form: NgForm) {
    if (form.invalid) {return; }
    console.log('formulario creado');
    console.log(this.sessionUser);
    console.log(form);
  }

}
