import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { User } from './models';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl = 'https://localhost:44336/api';

  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;

  constructor(private httpClient: HttpClient) {
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): User {
    return this.currentUserSubject.value;
  }

  getToken(): string {
    return localStorage.getItem('currentUser');
    // return JSON.stringify(localStorage.getItem('currentUser'));
  }

  logIn(user): Observable<any> { // it is email before, now try to use username, instead.
    debugger;
    const url = `${this.baseUrl}/Auth/signin`;
    console.log(user);
    return this.httpClient.post<any>(url, user)
    .pipe(map(response => {
      localStorage.setItem('currentUser', JSON.stringify(response.token));
      localStorage.setItem('token', JSON.stringify(response.token));
      localStorage.setItem('username', JSON.stringify(response.user.userName));
      localStorage.setItem('avatar', JSON.stringify(response.user.avatarImgUrl));
      return response;
    }));
  }

  signUp(email: string, password: string): Observable<User> {
    const url = `${this.baseUrl}/register`;
    return this.httpClient.post<User>(url, {email, password});
  }


  // Need to get the server side api endporint implementation to get the status
  getStatus(): Observable<User> {
    const url = `${this.baseUrl}/status`;
    return this.httpClient.get<User>(url);
  }

}
