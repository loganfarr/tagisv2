import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User } from './user';

@Injectable()

export class UserService {
  private _apiEndpoint = 'http://localhost:3010/api/';

  constructor(private _http: HttpClient) { }

  getUsers() {
    return this._http.get<User[]>(this._apiEndpoint + 'users');
  }

  postUser(user) {
    return this._http.post(this._apiEndpoint+'users', user);
  }

  getUser(uid) {
    return this._http.get<User[]>(this._apiEndpoint+'users/'+uid);
  }

  updateUser(user) {
    return this._http.put(this._apiEndpoint+'users/'+user._uid, user);
  }

  deleteUser(uid) {
    return this._http.delete(this._apiEndpoint+'users/'+uid);
  }

  getUserRoles() {
    return this._http.get<User[]>(this._apiEndpoint+'roles');
  }
}
