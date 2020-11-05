import { Component, OnInit, OnDestroy } from '@angular/core';
import { NgForm } from '@angular/forms';
import { SessionService } from 'src/app/services/sessions/session.service';
import {SessionUserModel} from '../../models/sessions/session-user-model';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {

  constructor(private sessionService: SessionService) {}

  sessionUser: SessionUserModel = new SessionUserModel();

  ngOnInit() {
  }

  login(form: NgForm) {

    if (form.invalid) {return; }
    this.sessionService.login(this.sessionUser).
      subscribe(resp => {
          console.log(resp);
        });
  }
  ngOnDestroy() {
  }

}
