// After the “Decider (Reducer)” is created, the “Caller” should be made as the “Final” called-in method for app.
// Typically its filename is “index.ts” under “reducers” directory.
// But in this case, it is called app.state.ts in the root of store - both options should work****

import { createFeatureSelector, createSelector, ActionReducerMap } from '@ngrx/store';

import * as auth from './auth.reducers';
import { User } from '../models';


// export interface AuthState {
//   authState: auth.State;
//   // ...
//   // More "States" relates to Auth workflow can be added here
// }

export interface AuthState {
  isAuthenticated: boolean;
  user: User | null;
  errorMessage: string | null;
  loading: boolean;
}

export const reducers = {
  authState: auth.reducer
};

// Here is the best part for using NGRX in production
// By defining the "Selector", app can call and get exactly combined data it required
// `createFeatureSelector` is for selecting a "Type" (AuthState)
// When requesting whole "Auth State", the app can call this const directly

export const selectAuthState = createFeatureSelector<AuthState>('auth');
