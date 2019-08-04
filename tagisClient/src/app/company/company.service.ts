import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';


import { Company } from './company';

@Injectable()

export class CompanyService {
  private _apiEndpoint = 'http://localhost:3010/api/';

  constructor(private _http: HttpClient) { }

  getAllCompanies() {
    return this._http.get<Company[]>(this._apiEndpoint+'companies');
  }

  getCompany(cid) {
    return this._http.get<Company>(this._apiEndpoint+'companies/'+cid);
  }

  getCompanyByName(name) {
    var machineName = this.getMachineName(name);
    return this._http.get<Company>(this._apiEndpoint+'companies/name/'+machineName);
  }

  getCompanyProducts(companies) {
    var companiesArray = companies.split(',');

    return this._http.post(this._apiEndpoint+'companies/products', companiesArray, {headers: {'Content-type': 'application/json', 'charset': 'utf-8'}});
  }

  getCompanyOrders(companies) {
    var companiesArray = companies.split(',');

    return this._http.post(this._apiEndpoint+'companies/orders', companiesArray, {headers: {'Content-type': 'application/json', 'charset': 'utf-8'}});
  }

  getCompanies(companies) {
    return this._http.post(this._apiEndpoint + 'companies/list', companies, {headers: {'Content-type': 'application/json', 'charset': 'utf-8'}});
  }

  getCompanyList() {
    return this._http.get<Company[]>(this._apiEndpoint+'companies/list');
  }

  getRecentCompanies() {
    return this._http.get<Company[]>(this._apiEndpoint+'companies/recent');
  }

  postCompany(company) {
    return this._http.post(this._apiEndpoint+'companies', company, {headers: {'Content-type': 'application/json', 'charset': 'utf-8'}});
  }

  updateCompany(company) {
    return this._http.put(this._apiEndpoint+'companies/'+company._cid, company, {headers: {'Content-type': 'application/json', 'charset': 'utf-8'}});
  }  

  deleteCompany(cid) {
    return this._http.delete(this._apiEndpoint+'companies/'+cid);
  }

  getMachineName(name: string) {
    var machineName = name.trim();
    machineName = machineName.split(' ').join('_');
    machineName = machineName.match(/[^_\W]+/g).join('_');
    machineName = machineName.toLowerCase();
    return machineName;
  }
}
