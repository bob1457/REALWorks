import { getErrorMsg, getLoadingStatus } from './../store/auth.reducers';
// import { AuthService } from './../auth.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
// import { Router } from '@angular/router';
import { Store, select } from '@ngrx/store';
import { AuthState } from '../store/auth.state';
import { LogIn } from '../store/auth.actions';
import { Observable } from 'rxjs';

@Component({
  selector: 'lib-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public loading: Observable<boolean>;
  public error: Observable<string>;

  checked = false;
  // loading = false;

  errMsg = 'Incorrect email and/or password.';
  email = '';


  // constructor(private authService: AuthService,
  //             private router: Router,
  //             private store: Store<AuthState>) {}
  constructor(private store: Store<AuthState>) {
    this.error = this.store.select(getErrorMsg);
  }

  ngOnInit() {
    // debugger;
     // set error
    // this.error = this.store.select(getErrorMsg);
    // this.error.subscribe(err => {console.log(err)});
    this.error = this.store.pipe(select(getErrorMsg))
     // set loading status
    this.loading = this.store.pipe(select(getLoadingStatus));
  }



  onSubmit(form: NgForm) {
    // debugger;
    console.log(form.value);
    // this.loading = true;



    const payload = form.value;
    this.store.dispatch(new LogIn(payload));

    // this.authService.logIn(form.value)
    // .subscribe(
    //   res => {
    //     console.log(res);
    //     if(!res.token) {
    //       this.errMsg = 'Authentication Failed!'
    //       this.loading = false;

    //     }
    //     else {
    //       this.router.navigate(['/Manage']);
    //     }
    //   },
    //   err => {
    //     console.log(err);
    //     this.errMsg = 'Authentication Failed, please try again!';
    //     this.loading = false;
    //   }
    // );

  }

  openDialog() {}
}
