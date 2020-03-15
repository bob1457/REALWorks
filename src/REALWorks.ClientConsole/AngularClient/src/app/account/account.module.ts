import { FlexLayoutModule } from '@angular/flex-layout';
import { AppMaterialModule } from './../app-material/app-material.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AccountRoutingModule } from './account-routing.module';

import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
//import { UserService } from './services/user.service';
import { ProfileComponent } from './profile/profile.component';
import { Ng4LoadingSpinnerModule } from 'ng4-loading-spinner';

@NgModule({
  imports: [
    CommonModule,
    AppMaterialModule,
    FlexLayoutModule,
    FormsModule,
    Ng4LoadingSpinnerModule,
    AccountRoutingModule
  ],
  declarations: [
    LoginComponent,
    RegisterComponent,
    ProfileComponent
  ],
  exports: [
    LoginComponent,
    RegisterComponent,
    FormsModule, ReactiveFormsModule,
    Ng4LoadingSpinnerModule,
    AppMaterialModule
  ],
  providers: [
    //UserService
  ]
})
export class AccountModule { }
