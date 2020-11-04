import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import {SessionUserModel} from '../../models/sessions/session-user-model';
import { SessionService } from '../../services/sessions/session.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  sessionUser: SessionUserModel;

  constructor(private authSession: SessionService) { }

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
