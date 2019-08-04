import { Component, OnInit, OnDestroy, ComponentFactoryResolver, ViewContainerRef, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Subscription } from 'rxjs';

import { NotificationsService } from 'angular2-notifications';

import { Order } from '../order';
import { Product } from '../product';
import { Company } from '../../company/company';

import { InventoryValidators } from '../inventory.validators';
import { OrderService } from '../order.service';
import { ProductService } from '../product.service';
import { CompanyService } from '../../company/company.service';

@Component({
  selector: 'add-order-form',
  templateUrl: './add-order-form.component.html',
  styleUrls: ['./add-order-form.component.css']
})
export class AddOrderFormComponent implements OnInit, OnDestroy {
  orderId: number = 0;
  addOrderForm;
  productList: Array<Product>;
  order: Order = new Order();
  companyList: Array<Company>;
  selectedCompany = new Company();

  sendReceiptEmail: Boolean = false;
  sendShippingEmail: Boolean = true;

  pageTitle: string = 'Add new order';

  productListSubscription: Subscription;
  companyListSubscription: Subscription;
  orderSubscription: Subscription;

  constructor(
    private _orderService: OrderService,
    private _productService: ProductService,
    private _formBuilder: FormBuilder,
    private _companyService: CompanyService,
    private _activatedRoute: ActivatedRoute,
    private _router: Router,
    private _notificationsService: NotificationsService) { }

  ngOnInit() {
    this.productListSubscription = this._productService.getProductList().subscribe(
      res => this.productList = res, 
      err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
    );

    this.companyListSubscription = this._companyService.getCompanyList().subscribe(
      res => this.companyList = res, 
      err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
    );

    this._activatedRoute.params.subscribe((params: Params) => {
      this.orderId = params['oid'];

      if(this.orderId != undefined && this.orderId > 0) {
        this.pageTitle = 'Edit order ' + this.orderId;

        this.orderSubscription = this._orderService.getOrder(this.orderId).subscribe(
          res => {
            res[0].products = JSON.parse(res[0].products);
            this.order = res[0];

            if(this.order.products.length > 0) {
              for (var i = 0; i < this.order.products.length; ++i) {
                this.addProducts(this.order.products[i].sku, this.order.products[i].quantity);
              }

              this.removeProduct(0);
            }
            else {
              console.log(this.order.products, this.order.products.length);
            }
          },
          err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
        );
      }
    });

    this.addOrderForm = this._formBuilder.group({
      products: this._formBuilder.array([
        this.initProducts()
      ]),
      subtotal: [],
      total: [],
      company: ['', [Validators.required, Validators.min(1)]],
      order_source: ['https://tagis.adventstores.com'],
      customer_name: ['', Validators.required],
      customer_email: ['', Validators.required],
      customer_phone: [''],
      customer_address1: ['', Validators.required],
      customer_address2: [''],
      customer_city: ['', Validators.required],
      customer_state: ['', Validators.required],
      customer_zip: ['', Validators.required],
      shipping_name: [''],
      shipping_address1: [''],
      shipping_address2: [''],
      shipping_city: [''],
      shipping_state: [''],
      shipping_zip: [''],
      ref: [''],
      shipping_number: [''],
      shipping_carrier: [''],
      send_order_receipt: [],
      send_shipping_notification: []
    });
  }

  ngOnDestroy() {
    this.productListSubscription.unsubscribe();
    this.companyListSubscription.unsubscribe();
    if(this.orderId)
      this.orderSubscription.unsubscribe();
  }

  initProducts(skuDefault = '', quantityDefault = 0) {
    return this._formBuilder.group({
      sku: [skuDefault, [
        Validators.required, 
        Validators.minLength(3)]],
      quantity: [quantityDefault, [Validators.required, Validators.min(0)]]
    });
  }

  addProducts(skuDefault = '', quantityDefault =  0) {
    const control = <FormArray>this.addOrderForm.controls['products'];
    control.push(this.initProducts(skuDefault, quantityDefault));
  }

  removeProduct(i: number) {
    const control = <FormArray>this.addOrderForm.controls['products'];
    control.removeAt(i);
  }

  checkInput(textbox) {
    if(textbox.value != '' && textbox.value != null) {
      textbox.classList.add('filled');
    }
    else if(textbox.value == '' && textbox.classList.contains('filled')) {
      textbox.classList.remove('filled');
    }

    return;
  }

  addCompany(company) {
    this.selectedCompany = company;
    this.addOrderForm.controls.company.setValue(this.selectedCompany._cid);
    console.log(this.selectedCompany);
  }

  checkSku(sku: string, index: number, $event) {
    console.log('checkSku', this.addOrderForm);
    this.checkInput($event);

    console.log(this.productList);

    if(sku != undefined && sku.length > 3) {
      var validSku = InventoryValidators.skuExists(sku, this.productList);

      if(!validSku) {
        this.addOrderForm.controls.products.controls[index].controls.sku.setErrors({ invalidSku: "The entered SKU does not exist."});
      }
    }
  }

  log(event) {
    console.log(event);
  }

  sendOrderReceipt() {
    this.sendReceiptEmail = true;
  }

  sendShippingInfo() {
    this.sendShippingEmail = true;
  }

  submitOrder(form) {
    this.order = form.value;
    // this.order.company = this.selectedCompany._cid;

    if((this.order.shipping_number != null && this.order.shipping_carrier == null) || (this.order.shipping_number == null && this.order.shipping_carrier != null)) {
      this.addOrderForm.setErrors({ inCompleteShipping : "Please enter both a shipping number and a shipping carrier."});
    } 

    if(this.orderId == 0) {
      this.order.created_date = this.formatDate();
    }
    else {
      this.order.last_modified_date = this.formatDate();
    }

    if(this.order.order_status == null || this.order.order_status == undefined)
      this.order.order_status = 'new';

    if(this.order.shipping_carrier && this.order.shipping_number && this.order.shipping_carrier != 'undefined' && this.order.shipping_number != 'undefined') {
      this.order.order_status = 'shipped';
    }
    
    if(this.order.subtotal != null && this.order.subtotal != NaN && this.order.total != null && this.order.total != NaN) {
      this.order.taxes = this.order.total - this.order.subtotal;
    }

    if(this.order.order_source == 'undefined') {
      this.order.order_source = 'https://tagis.adventstores.com';
    }

    console.log(this.addOrderForm, this.order, this.orderId);
    if(this.orderId == 0 || this.orderId == undefined) {
      this._orderService.postOrder(this.order).subscribe(
        res => { this._notificationsService.success('Order created successfully'); this._router.navigate(['/orders']); },
        err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
      );
    }
    else {
      this.order._oid = this.orderId;
      this._orderService.updateOrder(this.order).subscribe(
        res => { this._notificationsService.success('Order updated successfully'); this._router.navigate(['/orders']); },
        err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
      );
    }
  }

  formatDate(date?): string {
    var dateObject;

    if(date)
      dateObject = new Date(date);
    else
      dateObject = new Date();

    var month = (dateObject.getMonth() + 1) + "";

    if(month.length < 2)
      month = "0" + month;

    var day = dateObject.getDate() + "";

    if(day.length < 2)
      day = "0" + day;

    var formattedDate = dateObject.getFullYear() + "-" + month + "-" + day;

    return formattedDate;
  }
}
