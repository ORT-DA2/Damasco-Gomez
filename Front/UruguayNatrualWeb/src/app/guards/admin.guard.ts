import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { SessionService } from '../services/sessions/session.service';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {
  constructor (private session: SessionService,
              private router: Router) {}

  canActivate(): boolean {
    if (this.session.isAuthenticated() ){
      return true;
    } else {
      this.router.navigateByUrl('/login');
      return false;
    }
  }

}

