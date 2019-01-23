import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TenantRoutingModule } from './tenant-routing.module';

import { TenantComponent } from '../tenant/tenant/tenant.component';
import { TenantListComponent } from '../tenant/tenant-list/tenant-list.component';
import { TenantDetailsComponent } from '../tenant/tenant-details/tenant-details.component';

@NgModule({
  imports: [
    CommonModule,
    TenantRoutingModule
  ],
  exports: [
    TenantComponent, TenantListComponent, TenantDetailsComponent
  ],
  declarations: [TenantComponent, TenantListComponent, TenantDetailsComponent]
})
export class TenantModule { }
