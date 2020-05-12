import { EffectsModule } from '@ngrx/effects';
import { AppCoreModule } from '@lib/app-core';
import { AppMaterialModule } from '@lib/app-material';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppPmComponent } from './app.component';
import { PropertyHomeComponent } from './property-home/property-home.component';
import { PropertyListComponent } from './property-list/property-list.component';
import { PropertyDetailsComponent } from './property-details/property-details.component';
import { StoreModule } from '@ngrx/store';
import { reducer } from './store/reducers';
import { PropertyEffects } from './store/effects/property.effects';
import { OwnerListComponent } from './owner-list/owner-list.component';
import { ContractListComponent } from './contract-list/contract-list.component';
import { AddPropertyComponent } from './add-property/add-property.component';
import { AddOwnerComponent } from './add-owner/add-owner.component';
import { AddContractComponent } from './add-contract/add-contract.component';
import { ContractDetailsComponent } from './contract-details/contract-details.component';
import { OwnerDetailsComponent } from './owner-details/owner-details.component';
import { PropertyDetailsBasicComponent } from './property-details-basic/property-details-basic.component';
import { PropertyDetailsFeaturesComponent } from './property-details-features/property-details-features.component';
import { PropertyDetailsFacilitiesComponent } from './property-details-facilities/property-details-facilities.component';
import { AddPropertyFacilitiesComponent } from './add-property-facilities/add-property-facilities.component';
import { AddPropertyFeaturesComponent } from './add-property-features/add-property-features.component';
import { AddPropertyBasicComponent } from './add-property-basic/add-property-basic.component';
import { AddPropertyFinishComponent } from './add-property-finish/add-property-finish.component';
import { AddPropertyOwnerComponent } from './add-property-owner/add-property-owner.component';


@NgModule({
  declarations: [
    AppPmComponent,
    PropertyHomeComponent,
    PropertyListComponent,
    PropertyDetailsComponent,
    OwnerListComponent,
    ContractListComponent,
    AddPropertyComponent,
    AddOwnerComponent,
    AddContractComponent,
    ContractDetailsComponent,
    OwnerDetailsComponent,
    PropertyDetailsBasicComponent,
    PropertyDetailsFeaturesComponent,
    PropertyDetailsFacilitiesComponent,
    AddPropertyFacilitiesComponent,
    AddPropertyFeaturesComponent,
    AddPropertyBasicComponent,
    AddPropertyFinishComponent,
    AddPropertyOwnerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AppMaterialModule,
    AppCoreModule,
    StoreModule.forRoot([]),
    StoreModule.forFeature('property', reducer),
    EffectsModule.forFeature([PropertyEffects])
  ],
  providers: [],
  bootstrap: [AppPmComponent]
})
export class AppModule { }
