import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { NotificationsService } from 'angular2-notifications';

import { User } from '../user';
import { UserService } from '../user.service';

@Component({
  selector: 'app-add-user-form',
  templateUrl: './add-user-form.component.html',
  styleUrls: ['./add-user-form.component.css']
})
export class AddUserFormComponent implements OnInit {
  userId: number = 0;
  user = new User();

  roles = new Array();
  users: Array<User>;

  pageTitle: string = 'Add user';

  emailError = false;

  constructor(
    private _userService: UserService,
    private _router: Router,
    private _activatedRoute: ActivatedRoute,
    private _notificationsService: NotificationsService) { }

  ngOnInit() {
    this._activatedRoute.params.subscribe((params: Params) => {
      this.userId = params['uid'];
      this.user._uid = this.userId;

      if(this.userId != undefined && this.userId > 0) {
        this._userService.getUser(this.userId).subscribe(
          res => this.user = res[0],
          err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
        );
        this.pageTitle = 'Edit user';
      }
    });

    this._userService.getUsers().subscribe(
      res => this.users = res,
      err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
    );

    this._userService.getUserRoles().subscribe(
      res => this.roles = res,
      err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
    );
  }

  postUser(userValues) {
    if(userValues.company != '' && userValues.company != undefined)
      userValues.company = userValues.company.replace(/ /g, '');

    if(this.userId == undefined || this.userId  == 0) {
      this._userService.postUser(userValues).subscribe(
        res => {this._notificationsService.success('User created successfully'); this._router.navigate(['/users']); },
        err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
      );
    }
    else {
      this._userService.updateUser(userValues).subscribe(
        res => { this._notificationsService.success('User updated successfully'); this._router.navigate(['/users']); },
        err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
      );
    }
  }

  checkEmail(textbox) {
    for (var i = this.users.length - 1; i >= 0; i--) {
      if(this.users[i].email.toLowerCase() == textbox.value.toLowerCase()) {
        this.emailError = true;
        return;
      }
    }
  }

  checkInput(textbox) {
    if(textbox.value != '' && textbox.value != null) {
      textbox.classList.add('filled');
    }
    else if(textbox.value == '' && textbox.classList.contains('filled')) {
      textbox.classList.remove('filled');
    }

    return;
  }

  deleteUser(uid) {
    if(confirm('Are you sure you want to delete ' + this.user.first_name + ' ' + this.user.last_name + '?')) {
      return this._userService.deleteUser(uid).subscribe(
        res => {this._notificationsService.info('User deleted successfully'); this._router.navigate(['/users']); },
        err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
      );
    }
    else {
      return;
    }
  }
}
