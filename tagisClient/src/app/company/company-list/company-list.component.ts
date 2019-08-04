import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

import { NotificationsService } from 'angular2-notifications';

import { AuthService } from '../../user/auth.service';
import { Company } from '../company';
import { CompanyService } from '../company.service';

@Component({
  selector: 'company-list',
  templateUrl: './company-list.component.html',
  styleUrls: ['./company-list.component.css']
})
export class CompanyListComponent implements OnInit, OnDestroy {
  companies;
  subscription: Subscription;

  constructor(
    private _companyService: CompanyService,
    private _authService: AuthService,
    private _notificationsService: NotificationsService) { }

  ngOnInit() {
    var currentUser = this._authService.currentUser;

    if(currentUser.role != 4)
      this.subscription = this._companyService.getAllCompanies().subscribe(
        res => this.companies = res,
        err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
      );
    else 
      this.subscription = this._companyService.getCompanies(JSON.parse('[' + currentUser.company + ']')).subscribe(
        res => this.companies = res,
        err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
      );
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
