import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { Router } from '@angular/router';
import { AuthService, FacebookLoginProvider, GoogleLoginProvider } from 'angular-6-social-login-v2';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-facebook-login',
  templateUrl: './facebook-login.component.html',
  styleUrls: ['./facebook-login.component.scss']
})
export class FacebookLoginComponent implements OnInit {
  
  /*
  private authWindow: Window;
  failed: boolean;
  error: string;
  errorDescription: string;
  isRequesting: boolean;

  constructor(private userService: UserService, private router: Router) {
    if (window.addEventListener) {
      window.addEventListener('message', this.handleMessage.bind(this), false);
    } else {
       (<any>window).attachEvent('onmessage', this.handleMessage.bind(this));
    }
  }
*/

  constructor(private socialAuthService: AuthService, 
    private http: HttpClient,
    private router: Router
    ) { }

  ngOnInit() {
  }

  // launchFbLogin() {
    // tslint:disable-next-line:max-line-length
    // this.authWindow = window.open('https://www.facebook.com/v2.11/dialog/oauth?&response_type=token&display=popup&client_id=2244240055794794&display=popup&redirect_uri=http://localhost:5000/facebook-auth.html&scope=email',null,'width=600,height=400');    
  // }

  public facebookLogin() {
    // debugger;
    const socialPlatformProvider = FacebookLoginProvider.PROVIDER_ID;
    this.socialAuthService.signIn(socialPlatformProvider).then(
      (userData) => {
              // this will return user data from facebook. What you need is a user token which you will send it to the server
              localStorage.setItem('fbtoken', userData.token);
              console.log('facebook login token: ' + localStorage.getItem('fbtoken'));
              console.log(userData);
              this.router.navigate(['/todo']);
              this.sendToRestApiMethod(userData.token);
       }
    );
  } // Login errors are handled by Facebook login box

  /**
   * Private Implementation
   * */

  private sendToRestApiMethod(token: string): void {
    debugger;
    console.log('Send to api for processing...');
    this.http.post('', { token: token })
        .subscribe(onSuccess => {
                       // login was successful
                       // tslint:disable-next-line:max-line-length
                       // save the token that you got from your REST API in your preferred location i.e. as a Cookie or LocalStorage as you do with normal login
               }, onFail => {
                       // login was unsuccessful
                       // show an error message
               }
        );
}



  private handleMessage(event: Event) {

  }

}
