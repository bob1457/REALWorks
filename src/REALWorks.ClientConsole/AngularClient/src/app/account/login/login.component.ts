import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Http } from '@angular/http';
import { AuthService } from './../services/auth.service';
import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';
// import { FormGroup, FormBuilder, Validators, NgForm } from '@angular/forms';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  // userForm: FormGroup;
  errMsg = '';
  user;
  loading = false;

  constructor(private userService: UserService,
              private authService: AuthService,
              private router: Router,
              private http: HttpClient,
              private _http: Http,
              private spinnerService: Ng4LoadingSpinnerService
            ) { }

  ngOnInit() {
  }

  onSubmit(form: NgForm) {
    debugger;
    console.log(form.value);

    this.loading = true;

    this.authService.login(form.value)
        .subscribe(
          res => {
            console.log(res);
            if (!res) {
              this.errMsg = 'Authentication failed!';
            } else {
              this.router.navigate(['/manage']);
            }
          },
          err => {
            console.log(err);
            this.errMsg = 'Authentication Failed, please try again!';
            this.loading = false;
          }
        );
  }
}

