import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppMkComponent } from './app.component';
import { PropertyListingComponent } from './property-listing/property-listing.component';
import { MarketingHomeComponent } from './marketing-home/marketing-home.component';
import { ListingDetailsComponent } from './listing-details/listing-details.component';
import { reducer } from './store/reducers/marketing.reducers';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { MarketingEffects } from './store/effects/marketing.effects';
import { ApplicationListComponent } from './application-list/application-list.component';

@NgModule({
  declarations: [
    AppMkComponent,
    PropertyListingComponent,
    MarketingHomeComponent,
    ListingDetailsComponent,
    ApplicationListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    StoreModule.forRoot([]),
    StoreModule.forFeature('marketing', reducer),
    EffectsModule.forFeature([MarketingEffects])
  ],
  providers: [],
  bootstrap: [AppMkComponent]
})
export class AppModule { }
