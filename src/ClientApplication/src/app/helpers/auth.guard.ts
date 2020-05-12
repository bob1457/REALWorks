import { getLogInStatus } from './../../../projects/auth/src/lib/store/auth.reducers';
// import { getUserStatus } from './../../../projects/auth/src/lib/store/auth.reducers';

// import { AuthState } from './../../../projects/auth/src/lib/store/auth.state';
import { isLoggedIn } from '@lib/auth';
import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { AuthService } from '@lib/auth'; // ../../../projects/auth/src/lib/auth.service';
import { ObserversModule } from '@angular/cdk/observers';
import { Observable, from } from 'rxjs';
import { Store } from '@ngrx/store';
import * as fromAuth from '@lib/auth';

import { tap, take } from 'rxjs/operators';


@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {

  loginStatus$: Observable<boolean>;

  // isLoggedIn = false;

    constructor(
        private router: Router,
        private store: Store<fromAuth.AuthState>,
        private authService: AuthService
    ) {
      this.loginStatus$ = this.store.select(fromAuth.getLogInStatus);
      console.log(isLoggedIn);
      console.log(this.loginStatus$);
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
      debugger;
      const currentUser = localStorage.getItem('currentUser'); // this.authService.currentUserValue;
      console.log(currentUser);

      this.loginStatus$.subscribe((loggedIn) => {
        console.log(loggedIn);
      });

      if (currentUser) {
            // authorised so return true
            // this.isLoggedIn = true;
            return true;
        }

      // if (this.loginStatus$) {
      //     // authorised so return true
      //     // return true;
      // }

      // return this.loginStatus$.pipe(
      //   tap(status => {
      //     if(!status){
      //       this.router.navigate(['/']);
      //     }
      //     console.log('current status: ', status);
      //   }),
      //   take(1)
      // );




        // not logged in so redirect to login page with the return url
      this.router.navigate(['/']);
      return false;
    }
}
