import { FlexLayoutModule } from '@angular/flex-layout';
import { AppMaterialModule } from './../app-material/app-material.module';
import {BrowserModule} from '@angular/platform-browser';
// import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './layout/header/header.component';
import { SidenavComponent } from './layout/sidenav/sidenav.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { HomeComponent } from './home/home.component';
import { BrandComponent } from './brand/brand.component';
import { FooterComponent } from './layout/footer/footer.component';
import { DashUiComponent } from './dash-ui/dash-ui.component';
import { IndicatorComponent } from '../indicator/indicator.component';
import { AutofocusDirective } from '../app-core/autofocus.directive';
//import { AuthGuard } from '../account/services/auth.guard';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
//import { AuthInterceptor } from '../account/services/auth.interceptor';
import { LandlordListComponent } from './landlord-list/landlord-list.component';
import { LandlordDetailsComponent } from './landlord-details/landlord-details.component';
// import { MarketingComponent } from './marketing/marketing.component';
import { ScreeningComponent } from './screening/screening.component';
import { TaskListComponent } from './task-list/task-list.component';
import { CalendarComponent } from './calendar/calendar.component';
import { MessagesComponent } from './messages/messages.component';
import { LegalCasesComponent } from './legal-cases/legal-cases.component';
import { DocumentationComponent } from './documentation/documentation.component';
import { OverviewComponent } from './overview/overview.component';
import { ReportingComponent } from './reporting/reporting.component';

// import { PropertyComponent } from './property/property.component';

import { PropertyModule } from '../property/property.module'; // import the feature module here, also import components in routing module
import { LeaseModule } from '../lease/lease.module';
import { MarketingModule } from '../marketing/marketing.module';



@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    AppMaterialModule,
    FlexLayoutModule,
    PropertyModule,
    LeaseModule,
    MarketingModule,
    DashboardRoutingModule
  ],
  declarations: [
    HomeComponent,
    HeaderComponent,
    SidenavComponent,
    BrandComponent,
    FooterComponent,
    DashUiComponent,
    IndicatorComponent,
    AutofocusDirective,    
    //RentalListComponent,
    //RentalDetailsComponent,
    LandlordListComponent,
    LandlordDetailsComponent,
    //TenantListComponent,
    //TenantDetailsComponent,
    // MarketingComponent,
    ScreeningComponent,
    TaskListComponent,
    CalendarComponent,
    MessagesComponent,
    LegalCasesComponent,
    DocumentationComponent,
    OverviewComponent,
    ReportingComponent
  ],
  exports: [
    HomeComponent,
    HeaderComponent,
    SidenavComponent
  ],
  providers: [
    /** 
    AuthGuard,
    ,
    {
      provide : HTTP_INTERCEPTORS,
      useClass : AuthInterceptor,
      multi : true
    }*/
  ],
})
export class DashboardModule { }
