import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserModule } from '../user/user.module';
import { FileUploadModule } from 'ng2-file-upload';

import { StoreComponent } from './store/store.component';
import { StoreListComponent } from './store-list/store-list.component';
import { AddStoreFormComponent } from './add-store-form/add-store-form.component';
import { StoreService } from './store.service';
import { StoreSelectorComponent } from './store-selector/store-selector.component';
import { storeRouting } from './storeRouting';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    UserModule,
    FileUploadModule,
    storeRouting
  ],
  declarations: [
    StoreComponent,
    StoreListComponent,
    AddStoreFormComponent,
    StoreSelectorComponent
  ],
  providers: [
    StoreService
  ],
  exports: [
    StoreSelectorComponent
  ]
})
export class StoreModule { }
