import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { NotificationsService } from 'angular2-notifications';

import { Store } from '../store';
import { StoreService } from '../store.service';

import { Product } from '../../inventory/product';

@Component({
  selector: 'store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.css']
})
export class StoreComponent implements OnInit {
  storeId: number = 0;
  store: Store = new Store();

  products;
  filteredProducts;

  constructor(
    private _storeService: StoreService,
    private _activatedRoute: ActivatedRoute,
    private _notificationsService: NotificationsService) { }

  ngOnInit() {
    this._activatedRoute.params.subscribe((params: Params) => {
      this.storeId = params['cid'];

      if(this.storeId != undefined && this.storeId > 0) {
        this._storeService.getStore(this.storeId).subscribe(
          res => {
            this.store = res[0];
          },
          err => {
            this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage);
          }
        );

        this._storeService.getCompanyProducts(this.storeId).subscribe(
          res => this.filteredProducts = this.products = res,
          err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
        );
      }
    }); 
  }

  filterBySku(query) {
    this.filteredProducts = (query) ? this.products.filter(p => p.sku.toLowerCase().includes(query.toLowerCase())) : this.products;
  }

  filterByStore(query) {
    this.filteredProducts = (query) ? this.products.filter(p => p.store_title.toLowerCase().includes(query.toLowerCase())) : this.products;
  }

}
