import { Router, RouterModule } from '@angular/router';

import { LoginFormComponent } from './login-form/login-form.component';
import { AddUserFormComponent } from './add-user-form/add-user-form.component';
import { UserListComponent} from './user-list/user-list.component';

import { AuthGuard } from './auth-guards/auth-guard.service';
import { AdminGuard } from './auth-guards/admin-guard.service';
import { EmployeeGuard } from './auth-guards/employee-guard.service';

export const userRouting = RouterModule.forChild([
  { path: 'login', component: LoginFormComponent },
  { path: 'users/add', component: AddUserFormComponent, canActivate: [AuthGuard, AdminGuard] },
  { path: 'users/:uid/edit', component: AddUserFormComponent, canActivate: [AuthGuard, AdminGuard] },
  { path: 'users', component: UserListComponent, canActivate: [AuthGuard] }
]);