import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Subscription } from 'rxjs';

import { NotificationsService } from 'angular2-notifications';

import { Order } from '../order';
import { OrderService } from '../order.service';

@Component({
  selector: 'order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit, OnDestroy {
  orderId: number;
  order: Order = new Order();

  subscription: Subscription;

  constructor(
    private _router: Router,
    private _activatedRoute: ActivatedRoute,
    private _orderService: OrderService,
    private _notificationsService: NotificationsService) { }

  ngOnInit() {
    this._activatedRoute.params.subscribe((params: Params) => {
      this.orderId = params['oid'];

      if(this.orderId != undefined && this.orderId > 0) {
        this.subscription = this._orderService.getOrder(this.orderId).subscribe(
          res => {
            res[0].products = JSON.parse(res[0].products);
            this.order = res[0];
            console.log(this.order);
          },
          err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
        );
      }
    });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  cancelOrder() {
    this.order.orderStatus = 'cancelled';
    this._orderService.cancelOrder(this.orderId).subscribe(
      res => this._router.navigate(['/orders']),
      err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
    );
  }

}
