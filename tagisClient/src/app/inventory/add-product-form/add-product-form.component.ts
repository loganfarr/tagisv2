import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { FileSelectDirective, FileUploader } from 'ng2-file-upload';

import { NotificationsService } from 'angular2-notifications';

import { Store } from '../../store/store';
import { StoreService } from '../../store/store.service';
import { Product } from '../product';
import { ProductService } from '../product.service';

import { InventoryValidators } from '../inventory.validators';

@Component({
  selector: 'add-product-form',
  templateUrl: './add-product-form.component.html',
  styleUrls: ['./add-product-form.component.css']
})
export class AddProductFormComponent implements OnInit {
  productId: number = 0;
  product: Product = new Product();
  productSku: string = '';
  productList: Array<Product>;
  isSaving: boolean = false;

  selectedCompany = new Store();

  addProductForm;

  pageTitle = "Add new product";

   // private _apiEndPoint = '//tagis-stage-api.adventstores.com/api/products/upload-image';
  private _apiEndPoint = '//localhost:3010/api/products/upload-image';
  uploader = new FileUploader({
    url: this._apiEndPoint,
    itemAlias: 'productImage',
    // autoUpload: true
  });

  constructor(
    private _productService: ProductService,
    private _companyService: StoreService,
    private _formBuilder: FormBuilder,
    private _activatedRoute: ActivatedRoute,
    private _router: Router,
    private _notificationsService: NotificationsService) { }

  ngOnInit() {
    this._productService.getProductList().subscribe(
      res => this.productList = res,
      err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
    );

    this.addProductForm = this._formBuilder.group({
      sku: ['', [
        Validators.required, 
        Validators.minLength(3),
        InventoryValidators.validateSku
        ]
      ],
      product_title: ['', Validators.required],
      stock: ['', Validators.required],
      description: [''],
      company: ['', Validators.required],
      price: [''],
      cost: ['']
    });

    this._activatedRoute.params.subscribe((params: Params) => {
      this.productId = params['pid'];

      if(this.productId != 0 && this.productId != undefined) {
        this._productService.getProduct(this.productId).subscribe(
          res => { 
            this.product = res[0];
            this.pageTitle = "Edit product: " + this.product.product_title;
            this.productSku = this.product.sku;
            this.addProductForm.get('sku').disable();
          },
          err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
        );
      }
    });

    this.uploader.onAfterAddingFile = function(file) { file.withCredentials = false };
    this.uploader.onCompleteItem = (item, response, status, header) =>  this.uploadedImage(item, response, status, header);
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
    // this.addProductForm.controls.store.markAsValid();
    this.addProductForm.controls['store'].setValue(this.selectedCompany._cid);
    console.log(this.selectedCompany);
  }

  uploadImage() {
    var file = this.uploader.queue[0];
    file.upload();
  }

  uploadedImage(item, response, status, header) {
    console.log("FileUpload:Uploaded:", item, status, response);
    console.log(JSON.stringify(response));
    if(!response) {
      this._notificationsService.error('Could not upload product image', 'An unknown error occurred');
      return;
    }

    var responseObject = JSON.parse(response);

    this.product.image = responseObject.response.location;
    // this.store.image = 'https://the-advent-group.s3-us-west-2.amazonaws.com/tagis/company-logos/' + item.file.name;
    console.log(responseObject.response.location, this.product.image);
  }

  onSubmit(form) {
    this.isSaving = true;
    let formValues = this.addProductForm.value;

    console.log(this._productService.skuExists(formValues.sku));

    if(this._productService.skuExists(formValues.sku)) {
      this.addProductForm.find('sku').setErrors({skuExists: true});
    }
    else {
      this.product.sku = this.productSku ? this.productSku : formValues.sku;
      this.product.product_title = formValues.product_title;
      this.product.stock = formValues.stock;
      this.product.store = formValues.store;
      this.product.description = formValues.description;
      this.product.cost = formValues.cost !== "undefined" ? formValues.cost : null;
      this.product.price = formValues.price;

      if(this.productId == 0 || this.productId == undefined) {
        this._productService.postProduct(this.product).subscribe(
          res => {
            this.isSaving = false;
            this._notificationsService.success('Product created successfully');
            this._router.navigate(['/products']);
          },
          err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
        );
      }
      else {
        this._productService.updateProduct(this.product).subscribe(
          res => { this.isSaving = false; console.log(res); this._notificationsService.success('Product updated successfully'); this._router.navigate(['/products', this.product._pid]); },
          err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
        );
      }
    }
  }
}
