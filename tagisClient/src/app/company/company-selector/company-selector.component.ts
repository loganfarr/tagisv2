import { Component, OnInit, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';

import { NotificationsService } from 'angular2-notifications';

import { Company } from '../company';
import { CompanyService } from '../company.service';

@Component({
  selector: 'company-selector',
  templateUrl: './company-selector.component.html',
  styleUrls: ['./company-selector.component.css']
})
export class CompanySelectorComponent implements OnInit, OnChanges {
  companyList: Array<Object>;
  selectedCompany = new Company();
  @Input('saved-company') savedCompany;
  @Output('company-selected') companySelected = new EventEmitter();

  constructor(
    private _companyService: CompanyService,
    private _notificationsService: NotificationsService) { }

  ngOnInit() {
    this._companyService.getCompanyList().subscribe(res => this.companyList = res);

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
      this._companyService.getCompanyByName(textbox.value).subscribe(
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
        this.selectedCompany = new Company();
    }
  }

  setCompany(cid) {
    if(cid == undefined || cid == 0 || cid == NaN)
      return null;

    this._companyService.getCompany(cid).subscribe(
      res => {
        this.selectedCompany = res[0];
        this.companySelected.emit(this.selectedCompany);
      },
      err => this._notificationsService.error('Error #' + err.error.errCode, err.error.errMessage)
    );
  }
}
