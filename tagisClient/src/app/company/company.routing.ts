import { Router, RouterModule } from '@angular/router';

import { AuthGuard } from '../user/auth-guards/auth-guard.service';
import { AdminGuard } from '../user/auth-guards/admin-guard.service';
import { EmployeeGuard } from '../user/auth-guards/employee-guard.service';

import { AddCompanyFormComponent } from './add-company-form/add-company-form.component';
import { CompanyListComponent } from './company-list/company-list.component';
import { CompanyComponent } from './company/company.component';


export const companyRouting = RouterModule.forChild([
  { path: 'stores', component: CompanyListComponent, canActivate: [AuthGuard] },
  { path: 'companies', component: CompanyListComponent, canActivate: [AuthGuard] },
  { path: 'stores/add', component: AddCompanyFormComponent, canActivate: [AuthGuard, EmployeeGuard] },
  { path: 'companies/add', component: AddCompanyFormComponent, canActivate: [AuthGuard, AdminGuard] },
  { path: 'stores/edit/:cid', component: AddCompanyFormComponent, canActivate: [AuthGuard, EmployeeGuard] },
  { path: 'companies/edit/:cid', component: AddCompanyFormComponent, canActivate: [AuthGuard, EmployeeGuard] },
  { path: 'stores/:cid', component: CompanyComponent, canActivate: [AuthGuard] },
  { path: 'companies/:cid', component: CompanyComponent, canActivate: [AuthGuard] }
]);