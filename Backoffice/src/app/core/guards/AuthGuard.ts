import { AuthService } from '../services/_auth';
import { Router, CanActivate } from '@angular/router';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private _auth: AuthService, private router: Router) { }

  canActivate() {
    if (!this._auth.isLoggedIn()) {
      this.router.navigate(['/login']);
      return false
    }
    return true;
  }
}
