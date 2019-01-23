import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RentalListingComponent } from './rental-listing/rental-listing.component';

const routes: Routes = [
  { path: 'rental-listing', component: RentalListingComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MarketingRoutingModule { }
