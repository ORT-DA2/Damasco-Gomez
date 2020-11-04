import { Component, OnInit, OnDestroy } from '@angular/core';
import { NgForm } from '@angular/forms';
import {SessionUserModel} from '../../models/sessions/session-user-model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {
  constructor() {}

  sessionUser: SessionUserModel = new SessionUserModel();
  ngOnInit() {
  }

  login(form: NgForm) {

    if (form.invalid) {return; }
    console.log(form);
  }
  ngOnDestroy() {
  }

}
