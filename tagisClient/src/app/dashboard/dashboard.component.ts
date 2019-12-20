import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { NotificationsService } from 'angular2-notifications';

import { AuthService } from '../user/auth.service';
import { Store } from '../store/store';
import { StoreService } from '../store/store.service';
import { Order } from '../inventory/order';
import { OrderService } from '../inventory/order.service';
import { Product } from '../inventory/product';
import { ProductService } from '../inventory/product.service';
import { User } from '../user/user';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  orders: Array<Order>;
  products: Array<Product>;
  companies: Array<Store>;
  user;

  constructor(
    private _orderService: OrderService,
    private _companyService: StoreService,
    private _productService: ProductService,
    private _authService: AuthService,
    private _notificationsService: NotificationsService) {}

  ngOnInit() {
    this._orderService.getRecentOrders().subscribe(
      res => this.orders = res,
      err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
    );

    this._productService.getLowStockProducts().subscribe(
      res => this.products = res,
      err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
    );

    this._companyService.getRecentCompanies().subscribe(
      res => this.companies = res,
      err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
    );

    this.user = this._authService.currentUser;
  }

}
