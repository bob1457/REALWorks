import { state } from '@angular/animations';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { AppMaterialModule } from '@lib/app-material';
import { NgModule } from '@angular/core';
import { DashboardComponent } from './dashboard.component';
import { DashhomeComponent } from './dashhome/dashhome.component';
import { LayoutModule } from '@angular/cdk/layout';
import { ChartsModule } from 'ng2-charts';

import { reducer } from './store/dash.reducer';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { DashboardEffects } from './store/dash.effects';
import { DashPropertyComponent } from './dash-property/dash-property.component';
import { DashOwnerComponent } from './dash-owner/dash-owner.component';
import { DashContractComponent } from './dash-contract/dash-contract.component';
import { DashTenantComponent } from './dash-tenant/dash-tenant.component';
import { DashLeaseComponent } from './dash-lease/dash-lease.component';
import { DashListingComponent } from './dash-listing/dash-listing.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { IndicatorPropertyComponent } from './indicator-property/indicator-property.component';
import { IndicatorContractComponent } from './indicator-contract/indicator-contract.component';
import { IndicatorTenantsComponent } from './indicator-tenants/indicator-tenants.component';
import { IndicatorRentalsComponent } from './indicator-rentals/indicator-rentals.component';
import { PieChartComponent } from './charts/pie-chart/pie-chart.component';
import { BarChartComponent } from './charts/bar-chart/bar-chart.component';

@NgModule({
  declarations: [
    DashboardComponent,
    DashhomeComponent,
    DashPropertyComponent,
    DashOwnerComponent,
    DashContractComponent,
    DashTenantComponent,
    DashLeaseComponent,
    DashListingComponent,
    IndicatorPropertyComponent,
    IndicatorContractComponent,
    IndicatorTenantsComponent,
    IndicatorRentalsComponent,
    PieChartComponent,
    BarChartComponent
  ],
  imports: [
    BrowserModule,
    ChartsModule,
    LayoutModule,
    HttpClientModule,
    FlexLayoutModule,
    AppMaterialModule,
    LayoutModule,
    StoreModule.forFeature('dashboard', reducer),
    EffectsModule.forFeature([DashboardEffects])
  ],
  exports: [
    DashboardComponent,
    DashhomeComponent
  ]
})
export class DashboardModule { }


