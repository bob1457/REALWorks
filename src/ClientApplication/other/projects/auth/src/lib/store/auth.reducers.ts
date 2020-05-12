import { AuthActionTypes, All } from './auth.actions';
import { AuthState } from './auth.state';

import { createFeatureSelector, createSelector } from '@ngrx/store';

// Here is the state model of the app
// export interface State { // Define state - a type that will be used below in initialState and reducer function -- STRONGLY TYPED
//     isAuthenticated: boolean;
//     user: User | null;
//     errorMessage: string | null;
// }


// Here is the initial state set if no changes happened
export const initialState: AuthState = { // Define initial state
    isAuthenticated: false,
    user: null,
    errorMessage: null,
    loading: false
};

export function reducer(state = initialState, action: All): AuthState {
   // Case can be more complex
   // "Login" is not put since it's not used for representing a status (State)
// debugger;
  // Reducer implementation - update state in application state store
  // return type is State
switch (action.type) {
      case AuthActionTypes.LOGIN: {
        return {
          ...state, // short presentation of an array (Typescript specific) - what is in it - previous state value???
          // The username is retrieved from the "Action"
          // In production, user data should be defined as a model
          // Retrieving user data like, `user: action.payload.user <- a model`
          loading: true
        };
      }
      case AuthActionTypes.LOGIN_SUCCESS: {
        return {
          ...state, // short presentation of an array (Typescript specific) - what is in it - previous state value???
          isAuthenticated: true,
          // The username is retrieved from the "Action"
          // In production, user data should be defined as a model
          // Retrieving user data like, `user: action.payload.user <- a model`
          loading: false,
          user: {
            token: action.payload.token,
            // email: action.payload.email,
            username: action.payload.user.userName,
            firstname: action.payload.user.firstName,
            lastname: action.payload.user.lastName,
            avatarUrl: action.payload.user.avatarImgUrl,
            telephone1: action.payload.user.telephone1,
            telephone2: action.payload.user.telephone2,
            email: action.payload.user.email,
            joindate: action.payload.user.joinDate,
            lastlogin: action.payload.user.lastLogOn,
            lastupdated: action.payload.user.lastUpdated,
            socialmedia1: action.payload.user.socialMediaContact1,
            socialmedia2: action.payload.user.socialMediaContact2,
            role: action.payload.user.userRole,
            addressstreet: action.payload.user.addressStreet,
            addresscity: action.payload.user.addressCity,
            addressprovstate: action.payload.user.addressStateProv,
            addresspostzipcode: action.payload.user.addressZipPostCode,
            addresscountry: action.payload.user.addressCountry
          },
          errorMessage: null
        };
      }
      case AuthActionTypes.LOGIN_FAILURE: {
        return {
          ...state,
          loading: false,
          errorMessage: 'Incorrect email and/or password.'
        };
      }
      case AuthActionTypes.SIGNUP_SUCCESS: {
        return {
          ...state,
         isAuthenticated: true,
         loading: false,
          user: {
            token: action.payload.token,
            // email: action.payload.email,
            username: action.payload.username
          },
          errorMessage: null
        };
      }
      case AuthActionTypes.SIGNUP_FAILURE: {
        return {
          ...state,
          errorMessage: 'That email is already in use.'
        };
      }
      case AuthActionTypes.LOGOUT: {
        return initialState;
      }
      case AuthActionTypes.UPDATE_PROFILE: {
        return {
          ...state,
          loading: true
        };
      }
      case AuthActionTypes.UPDATE_AVATAR_SUCCESS: {
        return {
          ...state,
          loading: false,
          user: {
            // token: action.payload.token,
            // email: action.payload.email,
            // username: action.payload.user.userName,
            // firstname: action.payload.user.firstName,
            // lastname: action.payload.user.lastName,
            avatarUrl: action.payload.user.avatarImgUrl,
            // telephone: action.payload.user.telephone1,
            // email: action.payload.user.email,
            // joindate: action.payload.user.joinDate,
            // lastlogin: action.payload.user.lastLogOn,
            // lastupdated: action.payload.user.lastUpdated,
            // socialmedia: action.payload.user.socialMediaContact1,
            // role: action.payload.user.userRole
          },
          errorMessage: null
        };
      }
      case AuthActionTypes.UPDATE_AVATAR_FAILURE: {
        return {
          ...state,
          loading: false,
          errorMessage: 'Avatar image update failed.'
        }
      }
      case AuthActionTypes.UPDATE_PROFILE: {
        return {
          ...state,
          loading: true
        };
      }
      case AuthActionTypes.UPDATE_PROFILE_SUCCESS :
        return {
          ...state,
          loading: false,
          user: {
            // token: action.payload.token,
            // email: action.payload.email,
            // username: action.payload.user.userName,
            firstname: action.payload.user.firstName,
            lastname: action.payload.user.lastName,
            avatarUrl: action.payload.user.avatarImgUrl,
            telephone1: action.payload.user.telephone1,
            telephone2: action.payload.user.telephone2,
            email: action.payload.user.email,
            joindate: action.payload.user.joinDate,
            lastlogin: action.payload.user.lastLogOn,
            lastupdated: action.payload.user.lastUpdated,
            socialmedia1: action.payload.user.socialMediaContact1,
            socialmedia2: action.payload.user.socialMediaContact2,
            addressstreet: action.payload.user.addressStreet,
            addresscity: action.payload.user.addressCity,
            addressprovstate: action.payload.user.addressStateProv,
            addresspostzipcode: action.payload.user.addressZipPostCode,
            addresscountry: action.payload.user.addressCountry
            // role: action.payload.user.userRole
          },
          errorMessage: null
        }
        case AuthActionTypes.UPDATE_PROFILE_FAILURE: {
          return {
            ...state,
            loading: false,
            errorMessage:'Profile update failed.'
          };
        }
      default: {
        return state;
      }
    }
  }

// Use "Const" for getting read-only data managed by current "Reducer"
export const isLoggedIn = (state: AuthState) => state.isAuthenticated;
export const getUser = (state: AuthState) => state.user;
export const error = (state: AuthState) => state.errorMessage;
export const loading = (state: AuthState) => state.loading;


// Selectors: - possibly move to a separate selector file

export const getAuthStatus = createFeatureSelector<AuthState>('auth'); // Select required slice of state

export const getLogInStatus = createSelector(getAuthStatus, isLoggedIn);  // Select the attribute of the state in the slice
export const getErrorMsg = createSelector(getAuthStatus, error);
export const getLoadingStatus = createSelector(getAuthStatus, loading);
export const getUserInfo = createSelector(getAuthStatus, getUser);





