import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

import { NotificationsService } from 'angular2-notifications';

import { AuthService } from '../../user/auth.service'; 
import { CompanyService } from '../../company/company.service';
import { Order } from '../order';
import { OrderService } from '../order.service';
import { ProductService } from '../product.service';

@Component({
  selector: 'order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit, OnDestroy {
  orders;
  filteredOrders;

  subscription: Subscription;

  constructor(
    private _orderService: OrderService,
    private _productService: ProductService,
    private _companyService: CompanyService,
    private _authService: AuthService,
    private _notificationsService: NotificationsService) { }

  ngOnInit() {
    var currentUser = this._authService.currentUser;

    if(currentUser.role != 4) {
      this.subscription = this._orderService.getOrderList().subscribe(
        res => this.filteredOrders = this.orders = res,
        err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
      );
    }
    else {
      this.subscription = this._companyService.getCompanyOrders(currentUser.company).subscribe(
        res => this.filteredOrders = this.orders = res,
        err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
      );
    }
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  filterByOrderId(query) {
    this.filteredOrders = (query) ? this.orders.filter(o => o._oid.toString().includes(query.toLowerCase())) : this.orders;
  }

  filterByCompany(query) {
    this.filteredOrders = (query) ? this.orders.filter(o => o.company_title.toLowerCase().includes(query.toLowerCase())) : this.orders;
  }

  filterByCustomerName(query) {
    this.filteredOrders = (query) ? this.orders.filter(o => o.customer_name.toLowerCase().includes(query.toLowerCase())) : this.orders;
  }

  filterByStatus(query) {
    this.filteredOrders = (query) ? this.orders.filter(o => o.order_status.toLowerCase().includes(query.toLowerCase())) : this.orders;
  }
}
