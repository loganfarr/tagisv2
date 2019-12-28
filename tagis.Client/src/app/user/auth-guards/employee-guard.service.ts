import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';

import { AuthService } from '../auth.service';

@Injectable()

export class EmployeeGuard implements CanActivate {
  constructor(private _authService: AuthService) {}

  canActivate() {
    if(this._authService.isLoggedIn()) {
      var user = this._authService.currentUser;
      if(user.Role == 2 || user.Role == 1)
        return true;

      return false;
    }

    return false;
  }
}
