import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';


import { Order } from './order';

@Injectable()

export class OrderService {
  private _apiEndpoint = 'http://localhost:5000/';

  constructor(private _http: HttpClient) { }

  getAllOrders() {
    return this._http.get<Order[]>(this._apiEndpoint+'orders',{headers: {'X-Api-Key': '123'}});
  }

  getOrder(oid) {
    return this._http.get<Order>(this._apiEndpoint+'orders/'+oid,{headers: {'X-Api-Key': '123'}});
  }

  getOrderList() {
    return this._http.get<Order[]>(this._apiEndpoint+'orders/list',{headers: {'X-Api-Key': '123'}});
  }

  getRecentOrders() {
    return this._http.get<Order[]>(this._apiEndpoint+'orders/recent', {headers: {'X-Api-Key': '123'}});
  }

  postOrder(order) {
    return this._http.post(this._apiEndpoint+'orders', order, {headers: {'Content-type': 'application/json', 'charset': 'utf-8','X-Api-Key': '123'}});
  }

  updateOrder(order) {
    return this._http.put(this._apiEndpoint+'orders/'+order._oid, order, {headers: {'Content-type': 'application/json', 'charset': 'utf-8','X-Api-Key': '123'}});
  }

  deleteOrder(oid) {
    return this._http.delete(this._apiEndpoint+'orders/'+oid);
  }

  cancelOrder(oid) {
    return this._http.get<Order>(this._apiEndpoint+'orders/cancel/'+oid,{headers: {'X-Api-Key': '123'}});
  }
}
