import { Component, OnInit } from '@angular/core';

import { NotificationsService } from 'angular2-notifications';

import { User } from '../user';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  users: Array<User>;

  constructor(private _userService: UserService, private _notificationsService: NotificationsService) { }

  ngOnInit() {
    this._userService.getUsers().subscribe(
      res => this.users = res,
      err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
    );
  }

}
