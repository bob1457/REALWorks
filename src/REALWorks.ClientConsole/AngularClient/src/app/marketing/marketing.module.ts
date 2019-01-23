import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MarketingRoutingModule } from './marketing-routing.module';
import { RentalListingComponent } from './rental-listing/rental-listing.component';
import { MarketingComponent } from './marketing/marketing.component';
import { ApplicationsComponent } from './applications/applications.component'

import { ScreeningComponent } from './screening/screening.component';

@NgModule({
  imports: [
    CommonModule,
    MarketingRoutingModule
  ],
  exports: [
    RentalListingComponent
  ],
  declarations: [RentalListingComponent, MarketingComponent, ApplicationsComponent, ScreeningComponent]
})
export class MarketingModule { }
