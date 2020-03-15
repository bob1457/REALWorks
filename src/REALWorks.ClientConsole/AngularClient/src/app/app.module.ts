

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// import { AppMaterialModule } from './app-material/app-material.module';

import { AppRoutingModule } from './app-routing.module';
import { FlexLayoutModule, CoreModule } from '@angular/flex-layout';
// import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpModule, XHRBackend } from '@angular/http';

import { AppComponent } from './app.component';


import { AccountModule } from './account/account.module';
import { DashboardModule } from './dashboard/dashboard.module';

/*
import { LoginComponent } from './account/login/login.component';
import { HomeComponent } from './dashboard/home/home.component';
import { HeaderComponent } from './dashboard/layout/header/header.component';
*/

// Feature modules
import { AdministrationModule } from './administration/administration.module';
import { PropertyModule } from './property/property.module';
import { MarketingModule } from './marketing/marketing.module';
import { LeaseModule } from './lease/lease.module';
import { AnalyticsModule } from './analytics/analytics.module';
import { DocumentationModule } from './documentation/documentation.module';
import { TenantModule } from './tenant/tenant.module';
import { LegalModule } from './legal/legal.module';
import { AppCoreModule } from './app-core/app-core.module';


// Core Services
import { UserService } from './account/services/user.service';
import { JwtInterceptor } from './app-core/helpers/jwt.interceptor';

//import { AuthGuard } from './account/services/auth.guard';
//import { AuthInterceptor } from './account/services/auth.interceptor';





@NgModule({
  declarations: [
    AppComponent
    //IndicatorComponent//,
    //LoginComponent,  // Remember to declare components from the feature module imported (blow)
    // HomeComponent//,
    //HeaderComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    //AppMaterialModule,
    //FormsModule,
    //ReactiveFormsModule,
    HttpModule,
    HttpClientModule,
    FlexLayoutModule,
    AccountModule,
    DashboardModule,
    //CoreModule,
    AppCoreModule,
    AdministrationModule,
    PropertyModule,
    MarketingModule,
    LeaseModule,
    AnalyticsModule,
    DocumentationModule,
    TenantModule,
    LegalModule,
    AppRoutingModule
  ],
  providers: [
    // UserService
    UserService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }
    /**
    AuthGuard,
    ,
    {
      provide : HTTP_INTERCEPTORS,
      useClass : AuthInterceptor,
      multi : true
    } */
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
