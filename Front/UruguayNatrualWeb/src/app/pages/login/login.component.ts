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
export class LoginComponent implements OnInit, OnDestroy {

  constructor(private sessionService: SessionService,
               private router: Router ) {}

  sessionUser: SessionUserModel = new SessionUserModel();
  rememberMe = false;
  ngOnInit() {
    if (localStorage.getItem('email')){
      this.sessionUser.email = localStorage.getItem('email');
      this.rememberMe = true;
    }

  }

  login(form: NgForm) {

    if (form.invalid) {return; }

    this.sessionService.login(this.sessionUser).
      subscribe(resp => {
          console.log(resp);
          //this.router.navigateByUrl('/home');
        });

    if (this.rememberMe)
    {
      localStorage.setItem('email', this.sessionUser.email);
    }
  }
  rememberUser () {

  }
  ngOnDestroy() {
  }
/*
   if (  form.invalid ) { return; }

    Swal.fire({
      allowOutsideClick: false,
      type: 'info',
      text: 'Please Wait...'
    });
    Swal.showLoading();


    this.sessionService.login( this.sessionUser )
      .subscribe( resp => {

        console.log(resp);
        Swal.close();


      }, (err) => {

        console.log(err.error.error.message);
        Swal.fire({
          type: 'error',
          title: 'Authentication error',
          text: err.error.error.message
        });
      });
*/

}
