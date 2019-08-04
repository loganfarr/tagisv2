import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { FileSelectDirective, FileUploader } from 'ng2-file-upload';

import { NotificationsService } from 'angular2-notifications';

import { Company } from '../../company/company';
import { CompanyService } from '../../company/company.service';

@Component({
  selector: 'add-company-form',
  templateUrl: './add-company-form.component.html',
  styleUrls: ['./add-company-form.component.css']
})
export class AddCompanyFormComponent implements OnInit {
  companyId: number = 0;
  machineName: string;

  company: Company = new Company();

  addCompanyForm;

  private _apiEndPoint = '//tagis-stage-api.adventstores.com/api/companies/upload-logo';
  uploader = new FileUploader({
    url: this._apiEndPoint,
    itemAlias: 'companyLogo',
    // autoUpload: true
  });

  pageTitle = 'Add new store';

  constructor(
    private _companyService: CompanyService,
    private _formBuilder: FormBuilder,
    private _router: Router,
    private _activatedRoute: ActivatedRoute,
    private _notificationsService: NotificationsService) { }

  ngOnInit() {
    this.addCompanyForm = this._formBuilder.group({
      company_title: ['', Validators.required],
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
      this.companyId = params['cid'];

      if(this.companyId != undefined && this.companyId > 0) {
        this._companyService.getCompany(this.companyId).subscribe(
          res => {
            this.company = res[0];
            this.pageTitle = 'Edit store: ' + this.company.company_title;
            this.machineName = this.company.machine_name;

            this.addCompanyForm.get('company_title').disable();
          },
          err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
        );
      }
    });

    this.uploader.onAfterAddingFile = function(file) { file.withCredentials = false };
    this.uploader.onCompleteItem = (item, response, status, header) =>  this.uploadedLogo(item, response, status, header);
  }

  getCompany() {
    return this.company;
  }

  uploadedLogo(item, response, status, header) {
    console.log("FileUpload:Uploaded:", item, status, response);
    var responseObject = JSON.parse(response);
    this.company.logo = responseObject.response.location;
  }

  formatMachineName($event) {
    var name = $event.target.value;
    if(name != null && name != '' && name != undefined)
      this.machineName = this._companyService.getMachineName(name);
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

    // this.company = formValues;
    this.company.machine_name = this.machineName;
    this.company.address1 = formValues.address1;
    this.company.address2 = formValues.address2;
    this.company.city = formValues.city;
    this.company.state = formValues.state;
    this.company.contact_name = formValues.contact_name;
    this.company.contact_email = formValues.contact_email;
    this.company.contact_phone = formValues.contact_phone;
    this.company.website = formValues.website;
    this.company.company_store = formValues.company_store;
    this.company.product_api_endpoint = formValues.product_api_endpoint;
    this.company.order_api_endpoint = formValues.order_api_endpoint;
    this.company.discount = formValues.discount;
    this.company.coupon_code = formValues.coupon_code;

    // Only set the company name if creating a new company
    if(!this.companyId)
      this.company.company_title = formValues.company_title;
    else
      this.company._cid = this.companyId;

    console.log(this.company, this.company.company_title);

    if(this.companyId == undefined || this.companyId == 0) {
      this._companyService.postCompany(this.company).subscribe(
        res => { this._notificationsService.success('Company saved successfully'); this._router.navigate(['/stores']);},
        err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
      );
    }
    else {
      this._companyService.updateCompany(this.company).subscribe(
        res => {this._notificationsService.success('Company updated successfully'); this._router.navigate(['/stores']);},
        err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
      );
    }
  }
}
