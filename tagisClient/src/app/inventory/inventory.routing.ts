import { Router, RouterModule } from '@angular/router';

import { OrderComponent } from './order/order.component';
import { OrderListComponent } from './order-list/order-list.component';
import { AddOrderFormComponent } from './add-order-form/add-order-form.component';
import { ProductComponent } from './product/product.component';
import { ProductListComponent } from './product-list/product-list.component';
import { AddProductFormComponent } from './add-product-form/add-product-form.component';

import { AuthGuard } from '../user/auth-guards/auth-guard.service';
import { EmployeeGuard } from '../user/auth-guards/employee-guard.service';

export const inventoryRouting = RouterModule.forChild([
  { path: 'orders/add', component: AddOrderFormComponent, canActivate: [AuthGuard, EmployeeGuard] },
  { path: 'orders/:oid', component: OrderComponent, canActivate: [AuthGuard] },
  { path: 'orders/edit/:oid', component: AddOrderFormComponent, canActivate: [AuthGuard, EmployeeGuard] },
  { path: 'orders', component: OrderListComponent, canActivate: [AuthGuard] },
  { path: 'products/add', component: AddProductFormComponent, canActivate: [AuthGuard, EmployeeGuard] },
  { path: 'products/:pid', component: ProductComponent, canActivate: [AuthGuard] },
  { path: 'products/edit/:pid', component: AddProductFormComponent, canActivate: [AuthGuard, EmployeeGuard] },
  { path: 'products', component: ProductListComponent, canActivate: [AuthGuard] }
]);