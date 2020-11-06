import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
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
      this.router.navigateByUrl('/login'); // esto despuès se tiene que redirigir a las vistas para los turistas
      return false;
    }
  }

}

