import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PropertyListing } from '../models/property-listing.model';
import { RentalApplication } from '../models/rental-application.model';
import { PropertyImg } from '../models/property-img.model';

@Injectable({
  providedIn: 'root'
})
export class MarketingService {

  baseUrl = 'http://localhost:21799';

  constructor(protected http: HttpClient) { }

  getAllPropertyListings() {
    debugger;
    return this.http.get<PropertyListing[]>(`${this.baseUrl}/listings`);
  }

  getPropertyListingDetails(id: number) {
    debugger;
    return this.http.get<PropertyListing>(`${this.baseUrl}/listing/${id}`);
  }

  addPropertyListing(Listing: PropertyListing) {
    debugger;
    return this.http.post<PropertyListing>(`${this.baseUrl}/listing/add`, Listing);
  }

  updatePropertyListing(Listing: PropertyListing) {
    debugger;
    return this.http.post(`${this.baseUrl}/listing/update`, Listing);
  }

  getAllRentalApplications() {
    debugger;
    return this.http.get<RentalApplication[]>(`${this.baseUrl}/applications`);
  }

  getRentalApplicationDetails(id: number) {
    debugger;
    return this.http.get<RentalApplication>(`${this.baseUrl}/application/${id}`);
  }

  approveApplication(applicaton: any) {
    debugger;
    return this.http.post(`${this.baseUrl}/application/approve`, applicaton);
  }

  addImagesToListing(img: PropertyImg) {
    debugger;
    return this.http.post(`${this.baseUrl}/listing/addimg`, img);
  }

  removeImagesToListing(img: any) {
    debugger;
    return this.http.post(`${this.baseUrl}/listing/removeimg`, img);
  }

  deletePropertyListing(listing: any) {
    debugger;
    return this.http.post(`${this.baseUrl}/listing/remove`, listing);
  }

  changeListingStatus(listing: any) {
    debugger;
    return this.http.post(`${this.baseUrl}/listing/status`, listing);
  }

  addOpenHouse() {}

  updateOpenHouse() {}

  addOpenHouseViewer() {}

}
