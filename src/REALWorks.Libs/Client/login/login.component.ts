import { Authenticate } from './../store/actions/user.actions';
import { Component, OnInit } from '@angular/core';
import { User } from '../user.model';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
// import { isAuthenticated, State } from '../store/reducers/user.reducers';
import { selectUserState } from '../store/reducers';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  user: User = new User();
  getState: Observable<any>;
  error: string | null;

  constructor(private store: Store<any>) {
    this.getState = this.store.select(selectUserState);
   }

  ngOnInit() {
    debugger;
    // this.getState = this.store.select(isAuthenticated);
    this.getState.subscribe((state) => {
      console.log(state);
      this.error = state.error;
      console.log(state.error);
    });
  }

  onSubmit() {
    console.log(this.user);
    const payload = {
      email: this.user.email,
      username: this.user.username,
      password: this.user.password
    };

    console.log(payload);

    debugger;

    this.store.dispatch(new Authenticate(payload)); // This LogIn is from actions. Dispatch to reducer based on action
  }

}
