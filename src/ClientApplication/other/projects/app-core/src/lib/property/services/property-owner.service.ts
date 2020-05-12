import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PropertyOwner } from '../models/property-owner.model';


@Injectable({
  providedIn: 'root'
})
export class PropertyOwnerService {

  baseUrl = 'http://localhost:21799';

  constructor(protected http: HttpClient) { }

  ownerListByProperty: PropertyOwner[];





  addPropertyOwner(owner: PropertyOwner) {
    debugger;

    return this.http.post<PropertyOwner>(`${this.baseUrl}/property/addOwner`, owner);
  }

  // addExistingOwnerToProperty() {}

  removeOwner(owner: any) {
    debugger;
    return this.http.post(`${this.baseUrl}/property/remove`, owner);
  }

  updateOwner(owner: PropertyOwner) {
    debugger;
    return this.http.post<PropertyOwner>(`${this.baseUrl}/property/owner/update`, owner);
  }

  getPropertyOwnerList() {
    return this.http.get<PropertyOwner[]>(`${this.baseUrl}/property/owners`);
  }

  getPropertyDetails(id: number) {
    // return this.http.get<Property>(`${this.baseUrl}/property/${id});
    return this.http.get<PropertyOwner>(`${this.baseUrl}/property/owner/${id}`);
  }





}
