import { Component, OnInit, OnDestroy } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { SessionService } from 'src/app/services/sessions/session.service';
import Swal from 'sweetalert2';
import {SessionUserModel} from '../../models/sessions/session-user-model';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private sessionService: SessionService,
               private router: Router ) {}

  sessionUser: SessionUserModel = new SessionUserModel();
  ngOnInit() {
  }

  login(form: NgForm) {
    if (form.invalid) {return; }

    this.sessionService.login(this.sessionUser).
      subscribe(resp => {
           this.router.navigateByUrl('/user-profile');
        });
      localStorage.setItem('email', this.sessionUser.email);
  }

}
