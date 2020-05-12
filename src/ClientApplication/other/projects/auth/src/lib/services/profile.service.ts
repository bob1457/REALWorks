import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { Profile } from '../models/profile';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  // serverUrl = 'https://localhost:44336/api/Profile/update';
  serverUrl = 'http://localhost:58088/api/Profile/update';

  constructor(private httpClient: HttpClient) { }

  updateProfile(profile: Profile) {
    debugger;
    return this.httpClient.post(this.serverUrl, profile);
  }
}
