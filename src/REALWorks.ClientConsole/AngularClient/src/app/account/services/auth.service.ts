import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl = environment.authServerUrl;

  constructor(private http: HttpClient) { }

  login(user): Observable<any> {
    console.log(user);
    return this.http.post<any>(`${this.baseUrl}/api/auth/login`, user) // ;
    // return this.http.post<any>(`${this.baseUrl}/api/auth/signin`, user) // ;
    /**/.pipe(
      map(res => {
        if (res) {
          localStorage.setItem('currentUser', res);
          localStorage.setItem('username', user.username);
          console.log(localStorage.getItem('currentUser'));
        }

        return res;
      })
    );
  }

}

