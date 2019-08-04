import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {FileUploadModule} from 'ng2-file-upload';
import {StorageServiceModule} from 'angular-webstorage-service';

import {CompanyModule} from '../company/company.module';
import {SharedModule} from '../shared/shared.module';
import {UserModule} from '../user/user.module';

import {AddOrderFormComponent} from './add-order-form/add-order-form.component';
import {AddProductFormComponent} from './add-product-form/add-product-form.component';
import {OrderComponent} from './order/order.component';
import {OrderListComponent} from './order-list/order-list.component';
import {ProductComponent} from './product/product.component';
import {ProductListComponent} from './product-list/product-list.component';
import {ProductService} from './product.service';
import {OrderService} from './order.service';

import {inventoryRouting} from './inventory.routing';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        StorageServiceModule,
        CompanyModule,
        SharedModule,
        UserModule,
        FileUploadModule,
        inventoryRouting
    ],
    declarations: [
        AddOrderFormComponent,
        AddProductFormComponent,
        OrderComponent,
        OrderListComponent,
        ProductComponent,
        ProductListComponent
    ],
    providers: [
        ProductService,
        OrderService
    ]
})
export class InventoryModule {
}
