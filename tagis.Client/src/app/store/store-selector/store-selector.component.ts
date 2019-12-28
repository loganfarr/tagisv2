import { Component, OnInit, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';

import { NotificationsService } from 'angular2-notifications';

import { Store } from '../store';
import { StoreService } from '../store.service';

@Component({
  selector: 'store-selector',
  templateUrl: './store-selector.component.html',
  styleUrls: ['./store-selector.component.css']
})
export class StoreSelectorComponent implements OnInit, OnChanges {
  companyList: Array<Object>;
  selectedCompany = new Store();
  @Input('saved-store') savedCompany;
  @Output('store-selected') companySelected = new EventEmitter();

  constructor(
    private _storeService: StoreService,
    private _notificationsService: NotificationsService) { }

  ngOnInit() {
    this._storeService.getCompanyList().subscribe(res => this.companyList = res);

    if(this.savedCompany != 0 && this.savedCompany != undefined) {
      this.setCompany(this.savedCompany);
    }
  }

  ngOnChanges(changes: SimpleChanges) {
    if(changes.savedCompany && changes.savedCompany.currentValue != undefined) {
      this.setCompany(changes.savedCompany.currentValue);
    }
  }

  checkInput(event) {
    var textbox = event.target;

    if(textbox.value != '' && textbox.value != null) {
      textbox.classList.add('filled');
    }
    else if(textbox.value == '' && textbox.classList.contains('filled')) {
      textbox.classList.remove('filled');
    }

    return;
  }

  getCompany(event) {
    this.checkInput(event);
    var textbox = event.target;

    if(textbox.value != '') {
      this._storeService.getCompanyByName(textbox.value).subscribe(
        res => {
          if(Array.isArray(res)) {
            this.selectedCompany = res[0];
          }
          else {
            this.selectedCompany = res;
          }
          
          this.companySelected.emit(this.selectedCompany);
        },
        err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
      );
    }
    else {
      if(this.selectedCompany._cid != undefined)
        this.selectedCompany = new Store();
    }
  }

  setCompany(cid) {
    if(cid == undefined || cid == 0 || cid == NaN)
      return null;

    this._storeService.getStore(cid).subscribe(
      res => {
        this.selectedCompany = res[0];
        this.companySelected.emit(this.selectedCompany);
      },
      err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
    );
  }
}
