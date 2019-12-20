import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User } from './user';

@Injectable()

export class UserService {
  private _apiEndpoint = 'http://localhost:5000/';

  constructor(private _http: HttpClient) { }

  getUsers() {
    return this._http.get<User[]>(this._apiEndpoint + 'users',{headers:{'X-Api-Key': '123'}});
  }

  postUser(user) {
    return this._http.post(this._apiEndpoint+'users', user,{headers:{'X-Api-Key': '123'}});
  }

  getUser(uid) {
    return this._http.get<User[]>(this._apiEndpoint+'users/'+uid,{headers:{'X-Api-Key': '123'}});
  }

  updateUser(user) {
    return this._http.put(this._apiEndpoint+'users/'+user._uid, user,{headers:{'X-Api-Key': '123'}});
  }

  deleteUser(uid) {
    return this._http.delete(this._apiEndpoint+'users/'+uid,{headers:{'X-Api-Key': '123'}});
  }

  getUserRoles() {
    return this._http.get<User[]>(this._apiEndpoint+'roles',{headers:{'X-Api-Key': '123'}});
  }
}
