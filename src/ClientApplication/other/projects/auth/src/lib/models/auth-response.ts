import { User } from './User';

export interface AuthResponse {
  // success: boolean;
  // payload?: any;
  token: string;
  user: User;
  errorMsg: string;
}
