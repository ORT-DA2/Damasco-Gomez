import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SessionService } from 'src/app/services/sessions/session.service';

declare interface RouteInfo {
    admin: boolean;
    path: string;
    title: string;
    icon: string;
    class: string;
}
export const ROUTES: RouteInfo[] = [
    { path: '/user-profile', title: 'User profile',  icon:'ni-single-02 text-black', class: '' , admin:true},
    { path: '/login', title: 'Login',  icon:'ni-key-25 text-info', class: '' ,admin:false},
    { path: '/register', title: 'Register',  icon:'ni-circle-08 text-pink', class: '' , admin:false},
    { path: '/bookings', title: 'Bookings',  icon:'ni-book-bookmark text-red', class: '' ,admin:true },
    { path: '/tourist-points', title: 'Tourist Points',  icon:'ni-compass-04 text-yellow', class: '' ,admin:true},
    { path: '/categories', title: 'Categories',  icon:'ni-bullet-list-67 text-pink', class: '' ,admin:true},
    { path: '/houses', title: 'Houses',  icon:'ni-building text-blue', class: '' , admin:true},
    { path: '/search', title: 'Search',  icon:'ni-building text-yellow', class: '' , admin:false},
    { path: '/reports', title: 'Reports',  icon:'ni-shop text-red', class: '' , admin:true},
    { path: '/review', title: 'Review',  icon:'ni-chart-pie-35 text-blue', class: '' , admin:false},
    { path: '/import', title: 'Import',  icon:'ni-chart-pie-35 text-brown', class: '' , admin:true},
    { path: '/admin', title: 'Admin',  icon:'ni-circle-08 text-green', class: '' , admin:true},
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  public menuItems: any[];
  public isCollapsed = true;

  constructor(private router: Router, private sessionService : SessionService) { }

  ngOnInit() {
    const isAuthorizated = this.sessionService.isAuthenticated();
    this.menuItems = ROUTES.filter(x => x.admin === isAuthorizated);
    this.router.events.subscribe((event) => {
      this.isCollapsed = true;
   });
  }
}
