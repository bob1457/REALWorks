import { RouterActions, RouterActionTypes } from './router.actions';
// import { RouterActionTypes, Go, RouterActions } from './../../../projects/auth/src/lib/store/router.actions';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Location } from '@angular/common';

import { Action } from '@ngrx/store';
import { Effect, Actions, ofType } from '@ngrx/effects';

import * as actions from './router.actions';
import { tap, map } from 'rxjs/operators';
import * as routerActions from './router.actions';

@Injectable()
export class RouterEffects {
    constructor(
        private actions$: Actions,
        private router: Router,
        private location: Location
    ) { }

    @Effect({ dispatch: false })
    navigate$ = this.actions$.pipe(
      ofType<routerActions.Go>(RouterActionTypes.Go),
      map((action: routerActions.Go) => {
        return action.payload;
      }),
      tap((({ path, query:queryParams, extras}) => {
        this.router.navigate(path, { queryParams, ...extras });
      })
    ));

    @Effect({ dispatch: false })
    navigateBack$ = this.actions$
    .pipe(
      ofType<routerActions.Back>(RouterActionTypes.Back),
      tap(() => this.location.back));

    @Effect({ dispatch: false })
    navigateForward$ = this.actions$
    .pipe(
      ofType<routerActions.Back>(RouterActionTypes.Forward),
      tap(() => this.location.forward)
    );
}
