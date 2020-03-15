import { environment } from '../../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Http, Response, Headers, RequestOptionsArgs, RequestOptions } from '@angular/http';
import { User } from '../../common/model/user';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { map, catchError } from 'rxjs/operators';
import { BehaviorSubject } from 'rxjs';


@Injectable(
  { providedIn: 'root' }
)
export class UserService {
  
  public token: string;
  user: User;

  readonly baseUrl = environment.authServerUrl; // 'http://192.168.99.100:58088';

  constructor( private http: HttpClient, private _http: Http ) { }

  registerUser(user: User) {
    const body: User = {
      UserName: user.UserName,
      Password: user.Password,
      Email: user.Email,
      FirstName: user.FirstName,
      LastName: user.LastName
    };

    // tslint:disable-next-line:prefer-const
    let reqHeader = new HttpHeaders({'No-Auth': 'True'});

    return this.http.post(this.baseUrl + '/api/Account/register', body, { headers : reqHeader});
  }


  login(userName, password): Observable<boolean> {
    // const data = JSON.stringify({userName}, (password)); // + '&grant_type=password';
    // const data = { userName, password };
    const headers = new HttpHeaders;
    // headers.append('Content-Type', 'application/json');
    // headers.append('X-Requested-With', 'XMLHttpRequest');
    return this._http.post(this.baseUrl + '/api/auth/login', {userName, password})// , { headers: HttpHeaders })
    // .map(res => res.json());
    .map( (response: Response) => {

      const token = response.json() && response.json().token;

      const user = response.json();
                if (token) {
                  // store user details and jwt token in local storage to keep user logged in between page refreshes
                  localStorage.setItem('currentUser', token);
                  localStorage.setItem('username', userName);
                  return true;
                } else {
                  return false;
                }
      });
  }

  getUserProfile(username: string): Observable<User> {
    debugger;
    return  this.http.get<User>(this.baseUrl + '/api/Profile/user/' + username);
  }

  public get currentUserToken() {
    debugger;
    //return this.currentUserSubject.value;
    return this.token = localStorage.getItem('currentUser');
  }
}
