import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from 'rxjs/operators';

import { Token } from './token';

@Injectable()
export class AuthService {
  private _apiEndpoint = "http://localhost:3010/api/";
  private _jwtHelper;

  constructor(
    private _http: HttpClient,
    private _router: Router) {
    this._jwtHelper = new JwtHelperService();
  }

  login(credentials) {
    return this._http.post<Token>(this._apiEndpoint + 'users/authenticate', credentials).pipe(map(res => {
      let result = res;
      if(result && result.authenticated) {
        console.log('if');
        localStorage.setItem('tagisToken', result.authenticated);
        return true;
      }
      else {
        console.log('else');
        return false;
      }
    }));
  }

  logout() {
    localStorage.removeItem('tagisToken');
    this._router.navigate(['/login']);
  }

  isLoggedIn() {
    let token = localStorage.getItem('tagisToken');

    if(!token)
      return false;

    let expirationDate = this._jwtHelper.getTokenExpirationDate(token);
    let isExpired = this._jwtHelper.isTokenExpired(token);

    return !isExpired;
  }

  get currentUser() {
    let token = localStorage.getItem('tagisToken');

    if(!token)
      return null;

    return this._jwtHelper.decodeToken(token);
  }

}
