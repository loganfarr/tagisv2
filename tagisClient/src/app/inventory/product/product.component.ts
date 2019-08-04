import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Subscription } from 'rxjs';

import { NotificationsService } from 'angular2-notifications';

import { Product } from '../product';
import { ProductService } from '../product.service';

@Component({
  selector: 'product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  productId: number;
  product = new Product();

  subscription: Subscription;

  constructor(
    private _productService: ProductService,
    private _activatedRoute: ActivatedRoute,
    private _notificationsService: NotificationsService) { }

  ngOnInit() {
    this._activatedRoute.params.subscribe((params: Params) => {
      this.productId = params['pid'];

      if(this.productId != undefined && this.productId > 0) {
        this.subscription = this._productService.getProduct(this.productId).subscribe(
          res => this.product = res[0],
          err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
        );
      }
    });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  disableProduct() {
    this._productService.disableProduct(this.product._pid).subscribe(
        res => this._productService.getProduct(this.productId).subscribe(
              res => this.product = res[0],
              err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
          ),
        err => this._notificationsService.error('Error #' + err.error.errCode, 'Could not disable product')
    );
  }

  enableProduct() {
      this._productService.enableProduct(this.product._pid).subscribe(
          res => this._productService.getProduct(this.productId).subscribe(
            res => this.product = res[0],
            err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
            ),
          err => this._notificationsService.error('Error #' + err.error.errCode, 'Could not enable product')
      );
  }
}
