import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ReantalApplicationServiceService {
  baseUrl = 'http://localhost:21799';

  constructor(protected http: HttpClient) { }

  getAllApplications() {}

  getApplicationDetails() {}

  addApplication() {}

  approveApplication() {}


}
