import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { JwtHelperService } from '@auth0/angular-jwt';

import { LoginFormComponent } from './login-form/login-form.component';
import { UserService } from './user.service';
import { UserListComponent } from './user-list/user-list.component';
import { AddUserFormComponent } from './add-user-form/add-user-form.component';

import { AuthService } from './auth.service';
import { AuthGuard } from './auth-guards/auth-guard.service';
import { AdminGuard } from './auth-guards/admin-guard.service';
import { EmployeeGuard } from './auth-guards/employee-guard.service';

import { userRouting } from './user.routing';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    userRouting
  ],
  declarations: [
    LoginFormComponent, 
    UserListComponent, 
    AddUserFormComponent 
  ],
  providers: [
    UserService,
    AuthService,
    JwtHelperService,
    AuthGuard,
    AdminGuard,
    EmployeeGuard
  ]
})
export class UserModule { }
