import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

import { NotificationsService } from 'angular2-notifications';

import { AuthService } from '../../user/auth.service';
import { CompanyService } from '../../company/company.service';
import { Product } from '../product';
import { ProductService } from '../product.service';

@Component({
  selector: 'product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit, OnDestroy {
  products;
  filteredProducts;
  filteredByOutOfStock = false;
  filteredByStatus = false;

  subscription: Subscription;

  constructor(
    private _productService: ProductService,
    private _companyService: CompanyService,
    private _authService: AuthService,
    private _notificationsService: NotificationsService) { }

  ngOnInit() {
    var currentUser = this._authService.currentUser;

    if(currentUser.role != 4) {
      this.subscription = this._productService.getAllProducts().subscribe(
        res => {
          this.filteredProducts = this.products = res;
          console.log(this.products);
        },
        err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
      );      
    }
    else {
      this.subscription = this._companyService.getCompanyProducts(currentUser.company).subscribe(
        res => {
          this.filteredProducts = this.products = res;
          console.log(this.products);
        },
        err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
      );
    }

  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  filterByStatus() {
    this.filteredByStatus = !this.filteredByStatus;
    this.filteredProducts = (this.filteredByStatus) ? this.filteredProducts.filter(p => p.status == 1) : this.products;
  }

  filterByOutOfStock() {
    this.filteredByOutOfStock = !this.filteredByOutOfStock;
    console.log(this.filteredByOutOfStock);
    this.filteredProducts = (this.filteredByOutOfStock) ? this.filteredProducts.filter(p => p.stock > 0) : this.products;
  }

  filterBySku(query) {
    this.filteredProducts = (query) ? this.filteredProducts.filter(p => p.sku.toLowerCase().includes(query.toLowerCase())) : this.products;
  }

  filterByCompany(query) {
    this.filteredProducts = (query) ? this.filteredProducts.filter(p => p.company_title.toLowerCase().includes(query.toLowerCase())) : this.products;
  }
}
