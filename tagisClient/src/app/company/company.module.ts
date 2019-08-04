import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserModule } from '../user/user.module';
import { FileUploadModule } from 'ng2-file-upload';

import { CompanyComponent } from './company/company.component';
import { CompanyListComponent } from './company-list/company-list.component';
import { AddCompanyFormComponent } from './add-company-form/add-company-form.component';
import { CompanyService } from './company.service';
import { CompanySelectorComponent } from './company-selector/company-selector.component';
import { companyRouting } from './company.routing';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    UserModule,
    FileUploadModule,
    companyRouting
  ],
  declarations: [
    CompanyComponent, 
    CompanyListComponent, 
    AddCompanyFormComponent, 
    CompanySelectorComponent
  ],
  providers: [
    CompanyService
  ],
  exports: [
    CompanySelectorComponent
  ]
})
export class CompanyModule { }
