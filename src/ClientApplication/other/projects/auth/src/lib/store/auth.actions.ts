// import { updateContractSuccess, updatePropertyFailure } from './../../../../property-manager/src/app/store/actions/property.actions';
// import { AuthActionTypes } from './auth.actions';
// The single event that precisely describes “What Happened” with custom “Type” , and it typically s a string.

import { Action } from '@ngrx/store';
import { Authentication } from './authentication'; // import the interface (model) for type check
import { User } from '../models';

// Use 'enum' to be registered as a map later
export enum AuthActionTypes {
  LOGIN = '[Auth] Login',
  LOGIN_SUCCESS = '[Auth] Login Success',
  LOGIN_FAILURE = '[Auth] Login Failure',
  SIGNUP = '[Auth] Signup',
  SIGNUP_SUCCESS = '[Auth] Signup Success',
  SIGNUP_FAILURE = '[Auth] Signup Failure',
  LOGOUT = '[Auth] Logout',
  GET_STATUS = '[Auth] GetStatus',
  UPDATE_AVATAR = '[Auth] Update Avatar',
  UPDATE_AVATAR_SUCCESS = '[Auth] Update Avatar Success',
  UPDATE_AVATAR_FAILURE = '[Auth] Update Avatar Failure',
  UPDATE_PROFILE = '[Auth] Update Profile',
  UPDATE_PROFILE_SUCCESS = '[Auth] Update Profile Success',
  UPDATE_PROFILE_FAILURE = '[Auth] Update Profile Failure'
}

// Implement all actions types defined above
//
export class LogIn implements Action {
  readonly type = AuthActionTypes.LOGIN;
  constructor(public payload: Authentication) {} // ori: constructor(public payload: any) {}
  // the payload type could be enforced (strongly typed) by importing an interface that defines the parameters required for authentication
  // i.e. authentication data is defined in a model(interface)
}

export class LogInSuccess implements Action {
  readonly type = AuthActionTypes.LOGIN_SUCCESS;
  constructor(public payload: any) {}
}

export class LogInFailure implements Action {
  readonly type = AuthActionTypes.LOGIN_FAILURE;
  constructor(public payload: any) {}
}

export class SignUp implements Action {
  readonly type = AuthActionTypes.SIGNUP;
  constructor(public payload: any) {}
}

export class SignUpSuccess implements Action {
  readonly type = AuthActionTypes.SIGNUP_SUCCESS;
  constructor(public payload: any) {}
}

export class SignUpFailure implements Action {
  readonly type = AuthActionTypes.SIGNUP_FAILURE;
  constructor(public payload: any) {}
}

export class LogOut implements Action {
  readonly type = AuthActionTypes.LOGOUT;
}

export class GetStatus implements Action {
  readonly type = AuthActionTypes.GET_STATUS;
}



export class UpdateAvatar implements Action {
  readonly type = AuthActionTypes.UPDATE_AVATAR;
  constructor(public payload: any) {}
}

export class UpdateAvatarSuccess implements Action {
  readonly type = AuthActionTypes.UPDATE_AVATAR_SUCCESS;
  constructor(public payload: any) {}
}

export class UpdateAvatarFailure implements Action {
  readonly type = AuthActionTypes.UPDATE_AVATAR_FAILURE;
  constructor(public payload: any) {}
}


export class UpdateProfile implements Action {
  readonly type = AuthActionTypes.UPDATE_PROFILE;
}

export class UpdateProfileSuccess implements Action {
  readonly type = AuthActionTypes.UPDATE_PROFILE_SUCCESS;
  constructor(public payload: any) {}
}

export class UpdateProfileFailure implements Action {
  readonly type = AuthActionTypes.UPDATE_PROFILE_FAILURE;
  constructor(public payload: any) {}
}

// Export all actions
//
export type All =
  | LogIn
  | LogInSuccess
  | LogInFailure
  | SignUp
  | SignUpSuccess
  | SignUpFailure
  | LogOut
  | GetStatus
  | UpdateAvatar
  | UpdateAvatarSuccess
  | UpdateAvatarFailure
  | UpdateProfile
  | UpdateProfileSuccess
  | UpdateProfileFailure;

