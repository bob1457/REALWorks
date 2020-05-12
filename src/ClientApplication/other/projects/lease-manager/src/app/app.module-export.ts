// import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { AppMaterialModule } from '@lib/app-material';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppLMComponent } from './app.component';
import { Routes, RouterModule } from '@angular/router';

import { AllLeasesComponent } from './all-leases/all-leases.component';
import { AllTenantsComponent } from './all-tenants/all-tenants.component';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { reducer } from './store/reducers/lease.reducers';
import { LeaseEffects } from './store/effects/lease.effects';

const routes: Routes = [
  { path: '', component: AllLeasesComponent },
  { path: 'tenants', component: AllTenantsComponent}
];

@NgModule({
  declarations: [
    AppLMComponent,
    AllLeasesComponent,
    AllTenantsComponent
  ],
  imports: [
    // BrowserModule,
    CommonModule,
    AppMaterialModule,
    RouterModule.forChild(routes),
    StoreModule.forFeature('lease', reducer),
    EffectsModule.forFeature([LeaseEffects])
    // AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppLMComponent]
})
export class AppLMModule { }
