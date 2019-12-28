import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

import { NotificationsService } from 'angular2-notifications';

import { AuthService } from '../auth.service';

@Component({
  selector: 'login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {
  invalidLogin: boolean = false;

  constructor(
    private _authService: AuthService,
    private _router: Router,
    private _notificationsService: NotificationsService) { }

  ngOnInit() {

    if(this._authService.isLoggedIn()) {
      this._router.navigate(['/']);
    }
  }

  signIn(credentials) {
    // console.log(credentials);
    this._authService.login(credentials).subscribe(
      res => { 
        if (res) {
          this._router.navigate(['/']);
        }
        else  
          this.invalidLogin = true; 
      }, e => {
        if(e.status == 401 || e.status == 400) 
          this.invalidLogin = true;
        else 
          this._notificationsService.error('Error #' + e.error.errCode, e.error.errMessage)
      }
    );
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
}
