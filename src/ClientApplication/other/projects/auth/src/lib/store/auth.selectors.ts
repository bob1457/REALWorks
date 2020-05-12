// import { isLoggedIn } from '@lib/auth';
import { AuthState } from '../store/auth.state';
// import { isAuthenticated } from './auth.reducers';
import { state } from '@angular/animations';
import * as fromAuth from './auth.state';
import * as fromAuthReducer from './auth.reducers';
import { createSelector, createFeatureSelector } from '@ngrx/store';
// import { AppState } from 'src/app/store/app.state';

debugger;
const getAuthState = createFeatureSelector<fromAuth.AuthState>('auth');

export const IsLoggedIn = createSelector(getAuthState, (state: AuthState) => state.isAuthenticated);
