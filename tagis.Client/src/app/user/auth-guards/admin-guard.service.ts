import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';

import { AuthService } from '../auth.service';

@Injectable()

export class AdminGuard implements CanActivate {
  constructor(
    private _router: Router,
    private _authService: AuthService) {}

  canActivate() {
    if(this._authService.isLoggedIn()) {
      var currentUser = this._authService.currentUser;
      if(currentUser.Role == 1)
        return true;

      return false;
    }

    return false;
  }
}
