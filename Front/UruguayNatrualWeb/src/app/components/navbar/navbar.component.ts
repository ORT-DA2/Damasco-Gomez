import { Component, OnInit, ElementRef } from '@angular/core';
import { ROUTES } from '../sidebar/sidebar.component';
import { Location, LocationStrategy, PathLocationStrategy } from '@angular/common';
import { Router } from '@angular/router';
import { SessionService } from 'src/app/services/sessions/session.service';
import { SessionUserModel } from 'src/app/models/sessions/session-user-model';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  public focus;
  public listTitles: any[];
  public location: Location;
  public currentUser: string ;
  public isAutorizated: boolean = false;
  public sessionService: SessionService;
  constructor(location: Location,  private element: ElementRef, private router: Router, sessionUser: SessionService) {
    this.location = location;
    this.sessionService = sessionUser;

  }

  ngOnInit() {
    this.listTitles = ROUTES.filter(listTitle => listTitle);
    this.currentUser = localStorage.getItem('email');
    this.isUserLogged();
  }
  getTitle(){
    var titlee = this.location.prepareExternalUrl(this.location.path());
    if(titlee.charAt(0) === '#'){
        titlee = titlee.slice( 1 );
    }

    for(var item = 0; item < this.listTitles.length; item++){
        if(this.listTitles[item].path === titlee){
            return this.listTitles[item].title;
        }
    }
    return 'Dashboard';
  }
  logOut() {
    localStorage.removeItem('token');
    this.refreshPage();
  }
  refreshPage() { window.location.reload(); }

  isUserLogged ()
  {
    this.isAutorizated = this.sessionService.isAuthenticated();
  }

}
