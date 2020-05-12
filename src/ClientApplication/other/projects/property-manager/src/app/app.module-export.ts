import { ContractListComponent } from './contract-list/contract-list.component';
import { AppMaterialModule } from '@lib/app-material';
// import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AppPmComponent } from './app.component';
import { PropertyHomeComponent } from './property-home/property-home.component';
import { PropertyListComponent } from './property-list/property-list.component';
import { PropertyDetailsComponent } from './property-details/property-details.component';
import { StoreModule } from '@ngrx/store';
import { reducer } from './store/reducers';
import { OwnerListComponent } from './owner-list/owner-list.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { AddPropertyComponent } from './add-property/add-property.component';
import { AddOwnerComponent } from './add-owner/add-owner.component';
import { AddContractComponent } from './add-contract/add-contract.component';
import { OwnerDetailsComponent } from './owner-details/owner-details.component';
import { ContractDetailsComponent } from './contract-details/contract-details.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PropertyDetailsBasicComponent } from './property-details-basic/property-details-basic.component';
import { PropertyDetailsFacilitiesComponent } from './property-details-facilities/property-details-facilities.component';
import { PropertyDetailsFeaturesComponent } from './property-details-features/property-details-features.component';
import { AddPropertyBasicComponent } from './add-property-basic/add-property-basic.component';
import { AddPropertyFeaturesComponent } from './add-property-features/add-property-features.component';
import { AddPropertyFacilitiesComponent } from './add-property-facilities/add-property-facilities.component';
import { AddPropertyFinishComponent } from './add-property-finish/add-property-finish.component';
import { AddPropertyOwnerComponent } from './add-property-owner/add-property-owner.component';

const routes: Routes = [
  { path: '', component: PropertyHomeComponent,
    children: [
      { path: 'propertylist', component: PropertyListComponent},
      { path: 'propertydetails/:id', component: PropertyDetailsComponent},
      { path: 'addproperty', component: AddPropertyComponent},
      { path: 'addowner', component: AddOwnerComponent},
      { path: 'addcontract', component: AddContractComponent},
      { path: 'owners', component: OwnerListComponent},
      { path: 'ownerdetails/:id', component: OwnerDetailsComponent},
      { path: 'contracts', component: ContractListComponent },
      { path: 'contractdetails/:id', component: ContractDetailsComponent},
    ]
  },
  // { path: 'owners', component: OwnerListComponent,  outlet: 'property'},
  // { path: 'contracts', component: ContractListComponent }
];

@NgModule({
  declarations: [
    AppPmComponent,
    AddContractComponent,
    AddPropertyComponent,
    AddPropertyBasicComponent,
    AddPropertyFeaturesComponent,
    AddPropertyFacilitiesComponent,
    AddPropertyOwnerComponent,
    AddPropertyFinishComponent,
    AddOwnerComponent,
    PropertyHomeComponent,
    PropertyListComponent,
    PropertyDetailsComponent,
    PropertyDetailsBasicComponent,
    PropertyDetailsFacilitiesComponent,
    PropertyDetailsFeaturesComponent,
    OwnerListComponent,
    OwnerDetailsComponent,
    ContractListComponent,
    ContractDetailsComponent
  ],
  imports: [
    // BrowserModule,
    CommonModule,
    AppMaterialModule,
    FlexLayoutModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(routes),
    StoreModule.forFeature('property', reducer)
  ],
  providers: [],

  bootstrap: [AppPmComponent]
})
export class AppPmModule { }
