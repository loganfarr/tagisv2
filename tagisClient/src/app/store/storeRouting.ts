import { Router, RouterModule } from '@angular/router';

import { AuthGuard } from '../user/auth-guards/auth-guard.service';
import { AdminGuard } from '../user/auth-guards/admin-guard.service';
import { EmployeeGuard } from '../user/auth-guards/employee-guard.service';

import { AddStoreFormComponent } from './add-store-form/add-store-form.component';
import { StoreListComponent } from './store-list/store-list.component';
import { StoreComponent } from './store/store.component';


export const storeRouting = RouterModule.forChild([
  { path: 'stores', component: StoreListComponent, canActivate: [AuthGuard] },
  { path: 'stores', component: StoreListComponent, canActivate: [AuthGuard] },
  { path: 'stores/add', component: AddStoreFormComponent, canActivate: [AuthGuard, EmployeeGuard] },
  { path: 'stores/add', component: AddStoreFormComponent, canActivate: [AuthGuard, AdminGuard] },
  { path: 'stores/edit/:cid', component: AddStoreFormComponent, canActivate: [AuthGuard, EmployeeGuard] },
  { path: 'stores/edit/:cid', component: AddStoreFormComponent, canActivate: [AuthGuard, EmployeeGuard] },
  { path: 'stores/:cid', component: StoreComponent, canActivate: [AuthGuard] },
  { path: 'stores/:cid', component: StoreComponent, canActivate: [AuthGuard] }
]);
