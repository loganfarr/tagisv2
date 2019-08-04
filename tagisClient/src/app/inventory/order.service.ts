import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';


import { Order } from './order';

@Injectable()

export class OrderService {
  private _apiEndpoint = 'http://localhost:3010/api/';

  constructor(private _http: HttpClient) { }

  getAllOrders() {
    return this._http.get<Order[]>(this._apiEndpoint+'orders');
  }

  getOrder(oid) {
    return this._http.get<Order>(this._apiEndpoint+'orders/'+oid);
  }

  getOrderList() {
    return this._http.get<Order[]>(this._apiEndpoint+'orders/list');
  }

  getRecentOrders() {
    return this._http.get<Order[]>(this._apiEndpoint+'orders/recent');
  }

  postOrder(order) {
    return this._http.post(this._apiEndpoint+'orders', order, {headers: {'Content-type': 'application/json', 'charset': 'utf-8'}});
  }

  updateOrder(order) {
    return this._http.put(this._apiEndpoint+'orders/'+order._oid, order, {headers: {'Content-type': 'application/json', 'charset': 'utf-8'}});
  }

  deleteOrder(oid) {
    return this._http.delete(this._apiEndpoint+'orders/'+oid);
  }

  cancelOrder(oid) {
    return this._http.get<Order>(this._apiEndpoint+'orders/cancel/'+oid);
  }
}
