import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TenantComponent } from './tenant/tenant.component';
import { TenantDetailsComponent } from './tenant-details/tenant-details.component';
import { TenantListComponent } from './tenant-list/tenant-list.component';

const routes: Routes = [
  { path: 'tennts', component: TenantComponent},  
  { path: 'tenant-details/:id', component: TenantDetailsComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TenantRoutingModule { }
