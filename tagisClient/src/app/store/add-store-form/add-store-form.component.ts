import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { FileSelectDirective, FileUploader } from 'ng2-file-upload';

import { NotificationsService } from 'angular2-notifications';

import { Store } from '../store';
import { StoreService } from '../store.service';

@Component({
  selector: 'add-store-form',
  templateUrl: './add-store-form.component.html',
  styleUrls: ['./add-store-form.component.css']
})
export class AddStoreFormComponent implements OnInit {
  storeId: number = 0;
  machineName: string;

  store: Store = new Store();

  addStoreForm;

  private _apiEndPoint = '//tagis-stage-api.adventstores.com/api/stores/upload-logo';
  uploader = new FileUploader({
    url: this._apiEndPoint,
    itemAlias: 'companyLogo',
    // autoUpload: true
  });

  pageTitle = 'Add new store';

  constructor(
    private _storeService: StoreService,
    private _formBuilder: FormBuilder,
    private _router: Router,
    private _activatedRoute: ActivatedRoute,
    private _notificationsService: NotificationsService) { }

  ngOnInit() {
    this.addStoreForm = this._formBuilder.group({
      store_title: ['', Validators.required],
      address1: [''],
      address2: [''],
      city: [''],
      state: [''],
      zip: [''],
      contact_name: ['', Validators.required],
      contact_email: ['', Validators.required],
      contact_phone: [''],
      website: [''],
      company_store: [''],
      product_api_endpoint: [''],
      order_api_endpoint: [''],
      update_on_approval: [''],
      auth_token: [''],
      email_from_address: [''],
      emails_enabled: [''],
      discount: [''],
      coupon_code: ['']
    });

    this._activatedRoute.params.subscribe((params: Params) => {
      this.storeId = params['cid'];

      if(this.storeId != undefined && this.storeId > 0) {
        this._storeService.getStore(this.storeId).subscribe(
          res => {
            this.store = res[0];
            this.pageTitle = 'Edit store: ' + this.store.title;
            this.machineName = this.store.machine_name;

            this.addStoreForm.get('title').disable();
          },
          err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
        );
      }
    });

    this.uploader.onAfterAddingFile = function(file) { file.withCredentials = false };
    this.uploader.onCompleteItem = (item, response, status, header) =>  this.uploadedLogo(item, response, status, header);
  }

  getStore() {
    return this.store;
  }

  uploadedLogo(item, response, status, header) {
    console.log("FileUpload:Uploaded:", item, status, response);
    var responseObject = JSON.parse(response);
    this.store.logo = responseObject.response.location;
  }

  formatMachineName($event) {
    var name = $event.target.value;
    if(name != null && name != '' && name != undefined)
      this.machineName = this._storeService.getMachineName(name);
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

  uploadLogo() {
    var file = this.uploader.queue[0];
    file.upload();
  }

  onSubmit(form) {
    var formValues = form.value;

    // this.store = formValues;
    this.store.machine_name = this.machineName;
    this.store.address1 = formValues.address1;
    this.store.address2 = formValues.address2;
    this.store.city = formValues.city;
    this.store.state = formValues.state;
    this.store.contact_name = formValues.contact_name;
    this.store.contact_email = formValues.contact_email;
    this.store.contact_phone = formValues.contact_phone;
    this.store.websiteUrl = formValues.websiteUrl;
    this.store.storeUrl = formValues.storeUrl;
    this.store.product_api_endpoint = formValues.product_api_endpoint;
    this.store.order_api_endpoint = formValues.order_api_endpoint;
    this.store.discount = formValues.discount;
    this.store.coupon_code = formValues.coupon_code;

    // Only set the store name if creating a new store
    if(!this.storeId)
      this.store.title = formValues.title;
    else
      this.store._cid = this.storeId;

    console.log(this.store, this.store.title);

    if(this.storeId == undefined || this.storeId == 0) {
      this._storeService.postCompany(this.store).subscribe(
        res => { this._notificationsService.success('Store saved successfully'); this._router.navigate(['/stores']);},
        err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
      );
    }
    else {
      this._storeService.updateCompany(this.store).subscribe(
        res => {this._notificationsService.success('Store updated successfully'); this._router.navigate(['/stores']);},
        err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
      );
    }
  }
}
