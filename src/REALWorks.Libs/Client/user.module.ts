import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { LoginComponent } from './login/login.component';
import { MaterialModule } from '../material.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { StoreModule } from '@ngrx/store';
import { authReducer } from './store/reducers/user.reducers';
import { EffectsModule } from '@ngrx/effects';
import { UserEffects } from './store/effects';
import { FacebookLoginComponent } from './facebook-login/facebook-login.component';
import { SocialLoginModule, AuthServiceConfig, FacebookLoginProvider } from 'angular-6-social-login-v2';
import { getAuthServiceConfigs } from './socialLoginConfig';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    FlexLayoutModule,
    FormsModule,
    ReactiveFormsModule,
    SocialLoginModule,
    StoreModule.forFeature('user', authReducer),
    // EffectsModule.forFeature([UserEffects]),
    UserRoutingModule
  ],
  exports: [LoginComponent, FacebookLoginComponent],
  providers: [
    {
      provide: AuthServiceConfig,
      useFactory: getAuthServiceConfigs
    }
  ],
  declarations: [LoginComponent, FacebookLoginComponent]
})
export class UserModule { }
