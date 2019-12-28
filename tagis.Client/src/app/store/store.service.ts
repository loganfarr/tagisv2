import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';


import { Store } from './store';

@Injectable()

export class StoreService {
  private _apiEndpoint = 'http://localhost:5000/';

  constructor(private _http: HttpClient) { }

  getAllStores() {
    return this._http.get<Store[]>(this._apiEndpoint+'store',{headers:{'X-Api-Key': '123'}});
  }

  getStore(cid) {
    return this._http.get<Store>(this._apiEndpoint+'store/'+cid,{headers:{'X-Api-Key': '123'}});
  }

  getCompanyByName(name) {
    var machineName = this.getMachineName(name);
    return this._http.get<Store>(this._apiEndpoint+'store/name/'+machineName,{headers:{'X-Api-Key': '123'}});
  }

  getCompanyProducts(companies) {
    var companiesArray = companies.split(',');

    return this._http.post(this._apiEndpoint+'store/products', companiesArray, {headers: {'Content-type': 'application/json', 'charset': 'utf-8','X-Api-Key': '123'}});
  }

  getCompanyOrders(companies) {
    var companiesArray = companies.split(',');

    return this._http.post(this._apiEndpoint+'store/orders', companiesArray, {headers: {'Content-type': 'application/json', 'charset': 'utf-8','X-Api-Key': '123'}});
  }

  getCompanies(companies) {
    return this._http.post(this._apiEndpoint + 'store/list', companies, {headers: {'Content-type': 'application/json', 'charset': 'utf-8','X-Api-Key': '123'}});
  }

  getCompanyList() {
    return this._http.get<Store[]>(this._apiEndpoint+'store/list',{headers:{'X-Api-Key': '123'}});
  }

  getRecentCompanies() {
    return this._http.get<Store[]>(this._apiEndpoint+'store/recent',{headers:{'X-Api-Key': '123'}});
  }

  postCompany(company) {
    return this._http.post(this._apiEndpoint+'stores', company, {headers: {'Content-type': 'application/json', 'charset': 'utf-8','X-Api-Key': '123'}});
  }

  updateCompany(company) {
    return this._http.put(this._apiEndpoint+'store/'+company._cid, company, {headers: {'Content-type': 'application/json', 'charset': 'utf-8','X-Api-Key': '123'}});
  }  

  deleteCompany(cid) {
    return this._http.delete(this._apiEndpoint+'store/'+cid,{headers:{'X-Api-Key': '123'}});
  }

  getMachineName(name: string) {
    var machineName = name.trim();
    machineName = machineName.split(' ').join('_');
    machineName = machineName.match(/[^_\W]+/g).join('_');
    machineName = machineName.toLowerCase();
    return machineName;
  }
}
