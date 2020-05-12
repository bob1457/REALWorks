// import { AppState } from './../../../../../src/app/store/app.state';
// import * as fromRouter from './../../../../../src/app/store/router.actions';
import { User } from './../models/user';
import { Injectable } from '@angular/core';
import { Action, Store } from '@ngrx/store';
import { Router } from '@angular/router';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { Observable } from 'rxjs';

import * as AuthActions from './auth.actions';
// import * as RouterActions from './router.actions';

import { of } from 'rxjs'; // rxjs 6.xx only

/* The following import statements are to up removed upon successful migration to rxjs 6.xx
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/catch';*/


import { tap, map, switchMap, catchError, exhaustMap, mergeMap } from 'rxjs/operators'; // rxjs 6.xx only

import { AuthService } from '../auth.service';
import {
  AuthActionTypes,
  LogIn, LogInSuccess, LogInFailure,
  SignUp, SignUpSuccess, SignUpFailure,
  LogOut,
} from './auth.actions';
import { Authentication } from './authentication';
import { HttpErrorResponse } from '@angular/common/http';
import { AuthState } from './auth.state';



@Injectable()
export class AuthEffects {

  constructor(
    private actions: Actions,
    private authService: AuthService,
    private store: Store<AuthState>,
    private router: Router
  ) {}
/*
  @Effect()
  LogIn: Observable<any> = this.actions
    .ofType(AuthActionTypes.LOGIN)
    .pipe(map((action: LogIn) => action.payload), switchMap(payload => {
      return this.authService.logIn(payload.email, payload.password)
        .map((user) => {
          return new LogInSuccess({token: user.token, email: payload.email});
        })
        .catchError((error) => {
          return Observable.of(new LogInFailure({ error: error }));
        });
    })
  );
*/

  @Effect()
  // debugger;
  login$: Observable<Action> = this.actions.pipe(
    ofType<AuthActions.LogIn>(AuthActionTypes.LOGIN),
    map((action: AuthActions.LogIn) => action.payload),
    exhaustMap((credits: Authentication) =>
      this.authService.logIn(credits).pipe(
        mergeMap((data: User) => [
          new AuthActions.LogInSuccess(data) // ,
          // console.log('received: ', data)
          // new RouterActions.Go({path: '/Manage'})
          // localStorage.setItem('user', JSON.stringify(data))
          // tap(data => {localStorage.setItem('auth', JSON.stringify(data))})
        ]),
        // tap(userDate => localStorage.setItem('auth', JSON.stringify(userDate))),
        catchError((err: HttpErrorResponse) => of(new LogInFailure(err.error)))
      ))
  );

  @Effect({ dispatch: false })
  LogInSuccess = this.actions.pipe(
    ofType(AuthActionTypes.LOGIN_SUCCESS),
    map((action: AuthActions.LogInSuccess) => action.payload),
    tap(() => this.router.navigate(['./Manage'])
  ));

  // this.store.dispatch( new fromRouter.Go({ path: ['/Manage']}) )

  // @Effect()
  // LogIn: Observable<any> = this.actions
  //   .ofType(AuthActionTypes.LOGIN)
  //   .map((action: LogIn) => action.payload)
  //   .switchMap(payload => {
  //     return this.authService.logIn(payload.username, payload.password) // initial http call to server web api to redeige an observable
  //       .map((user) => {
  //         return new LogInSuccess({token: user.token, username: payload.username});
  //       })
  //       .catch((error) => {
  //         return Observable.of(new LogInFailure({ error: error }));
  //       });
  //   });

/*
  @Effect({ dispatch: false })
  LogInSuccess: Observable<any> = this.actions.pipe(
    ofType(AuthActionTypes.LOGIN_SUCCESS),
    tap((user) => {
      // console.log('login successful!');
      localStorage.setItem('token', user.payload.token);
      // console.log(localStorage.getItem('token'));
      // console.log(user);
      this.router.navigateByUrl('/profile');
    })
  );

  @Effect({ dispatch: false })
  LogInFailure: Observable<any> = this.actions.pipe(
    ofType(AuthActionTypes.LOGIN_FAILURE)
  );

  @Effect()
  SignUp: Observable<any> = this.actions
    .ofType(AuthActionTypes.SIGNUP)
    .map((action: SignUp) => action.payload)
    .switchMap(payload => {
      return this.authService.signUp(payload.email, payload.password)
        .map((user) => {
          return new SignUpSuccess({token: user.token, email: payload.email});
        })
        .catch((error) => {
          return Observable.of(new SignUpFailure({ error: error }));
        });
    });

  @Effect({ dispatch: false })
  SignUpSuccess: Observable<any> = this.actions.pipe(
    ofType(AuthActionTypes.SIGNUP_SUCCESS),
    tap((user) => {
      localStorage.setItem('token', user.payload.token);
      this.router.navigateByUrl('/');
    })
  );

  @Effect({ dispatch: false })
  SignUpFailure: Observable<any> = this.actions.pipe(
    ofType(AuthActionTypes.SIGNUP_FAILURE)
  );



  @Effect({ dispatch: false })
  GetStatus: Observable<any> = this.actions
    .ofType(AuthActionTypes.GET_STATUS)
    .switchMap(payload => {
      return this.authService.getStatus();
    });
*/

@Effect({ dispatch: false })
  LogInFailure = this.actions.pipe(
    ofType(AuthActionTypes.LOGIN_FAILURE)
  );

@Effect({ dispatch: false })
  public LogOut: Observable<Action> = this.actions.pipe(
    ofType(AuthActionTypes.LOGOUT),
    tap((user) => {
      // localStorage.removeItem('currentUser');
      localStorage.clear();
      this.router.navigate(['./']);
      // this.store.dispatch(new fromRouter.Go({ path: ['/Manage']}));
    })
  );

@Effect()
updateAvatar$: Observable<Action> = this.actions.pipe(
  ofType<AuthActions.UpdateAvatar>(AuthActionTypes.LOGIN),
  map((action: AuthActions.UpdateAvatar) => action.payload),
  exhaustMap((credits: Authentication) =>
    this.authService.logIn(credits).pipe(
      mergeMap((data: User) => [
        new AuthActions.LogInSuccess(data) // ,
        // console.log('received: ', data)
        // new RouterActions.Go({path: '/Manage'})
        // localStorage.setItem('user', JSON.stringify(data))
        // tap(data => {localStorage.setItem('auth', JSON.stringify(data))})
      ]),
      // tap(userDate => localStorage.setItem('auth', JSON.stringify(userDate))),
      catchError((err: HttpErrorResponse) => of(new LogInFailure(err.error)))
    ))
  );
}
