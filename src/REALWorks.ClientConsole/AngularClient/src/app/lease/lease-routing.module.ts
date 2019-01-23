import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RentalComponent } from '../lease/rental/rental.component';
import { RentalListComponent } from '../lease/rental-list/rental-list.component';

const routes: Routes = [
  { path: 'rental', component: RentalComponent},
  { path: 'rental_list', component: RentalListComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LeaseRoutingModule { }
