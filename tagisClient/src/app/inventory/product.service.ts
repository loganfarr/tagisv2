import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';


import { Product } from './product';

@Injectable()

export class ProductService {
  private _apiEndpoint = 'http://localhost:3010/api/';

  constructor(private _http: HttpClient) { }

  getAllProducts() {
    return this._http.get<Product[]>(this._apiEndpoint+'products');
  }

  getProductList() {
    return this._http.get<Product[]>(this._apiEndpoint+'products/list');
  }

  postProduct(product) {
    return this._http.post(this._apiEndpoint+'products', product, {headers: {'Content-type': 'application/json', 'charset': 'utf-8'}});
  }

  getProduct(pid) {
    return this._http.get<Product>(this._apiEndpoint+'products/'+pid);
  }

  getLowStockProducts() {
    return this._http.get<Product[]>(this._apiEndpoint+'products/lowStock');
  }

  updateProduct(product) {
    return this._http.put(this._apiEndpoint+'products/'+product._pid, product, {headers: {'Content-type': 'application/json', 'charset': 'utf-8'}});
  }

  deleteProduct(pid) {
    return this._http.delete(this._apiEndpoint+'products/'+pid);
  }

  disableProduct(pid) {
    return this._http.get(this._apiEndpoint+'products/disable/'+pid);
  }

  enableProduct(pid) {
      return this._http.get(this._apiEndpoint+'products/enable/'+pid);
  }

  skuExists(sku) {
    this.getProductList().subscribe(res => {
      let productList = res;

      for (let i = 0; i < productList.length; ++i) {
        if(sku == productList[i].sku) {
          return true
        }
      }

      return false;
    });
  }
}
