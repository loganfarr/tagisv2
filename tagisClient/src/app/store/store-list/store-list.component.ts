import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

import { NotificationsService } from 'angular2-notifications';

import { AuthService } from '../../user/auth.service';
import { Store } from '../store';
import { StoreService } from '../store.service';

@Component({
  selector: 'store-list',
  templateUrl: './store-list.component.html',
  styleUrls: ['./store-list.component.css']
})
export class StoreListComponent implements OnInit, OnDestroy {
  companies;
  subscription: Subscription;

  constructor(
    private _storeService: StoreService,
    private _authService: AuthService,
    private _notificationsService: NotificationsService) { }

  ngOnInit() {
    var currentUser = this._authService.currentUser;

    if(currentUser.role != 4)
      this.subscription = this._storeService.getAllCompanies().subscribe(
        res => this.companies = res,
        err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
      );
    else 
      this.subscription = this._storeService.getCompanies(JSON.parse('[' + currentUser.store + ']')).subscribe(
        res => this.companies = res,
        err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
      );
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
