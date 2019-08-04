import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule }  from '@angular/router';

import { SimpleNotificationsModule } from 'angular2-notifications';

import { routing } from './app.routing';

import { CompanyModule } from './company/company.module';
import { InventoryModule } from './inventory/inventory.module';
import { SharedModule } from './shared/shared.module';
import { UserModule } from './user/user.module';

import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule,
    BrowserAnimationsModule,
    SimpleNotificationsModule.forRoot(),
    CompanyModule,
    InventoryModule,
    SharedModule,
    UserModule,
    routing
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
