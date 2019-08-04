import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { NotificationsService } from 'angular2-notifications';

import { Company } from '../company';
import { CompanyService } from '../company.service';

import { Product } from '../../inventory/product';

@Component({
  selector: 'company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css']
})
export class CompanyComponent implements OnInit {
  companyId: number = 0;
  company: Company = new Company();

  products;
  filteredProducts;

  constructor(
    private _companyService: CompanyService,
    private _activatedRoute: ActivatedRoute,
    private _notificationsService: NotificationsService) { }

  ngOnInit() {
    this._activatedRoute.params.subscribe((params: Params) => {
      this.companyId = params['cid'];

      if(this.companyId != undefined && this.companyId > 0) {
        this._companyService.getCompany(this.companyId).subscribe(
          res => {
            this.company = res[0];
          },
          err => {
            this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage);
          }
        );

        this._companyService.getCompanyProducts(this.companyId).subscribe(
          res => this.filteredProducts = this.products = res,
          err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
        );
      }
    }); 
  }

  filterBySku(query) {
    this.filteredProducts = (query) ? this.products.filter(p => p.sku.toLowerCase().includes(query.toLowerCase())) : this.products;
  }

  filterByCompany(query) {
    this.filteredProducts = (query) ? this.products.filter(p => p.company_title.toLowerCase().includes(query.toLowerCase())) : this.products;
  }

}
