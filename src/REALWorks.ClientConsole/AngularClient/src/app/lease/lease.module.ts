import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LeaseRoutingModule } from './lease-routing.module';

import { RentalComponent } from './rental/rental.component';
import { RentalListComponent } from './rental-list/rental-list.component';
import { RentalDetailsComponent } from './rental-details/rental-details.component';

import { AppMaterialModule } from '../app-material/app-material.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule } from '@angular/forms';
import { Ng4LoadingSpinnerModule } from 'ng4-loading-spinner';

@NgModule({
  imports: [
    CommonModule,
    AppMaterialModule,
    FlexLayoutModule,
    FormsModule,
    Ng4LoadingSpinnerModule,
    LeaseRoutingModule
  ],
  exports: [
    RentalComponent, RentalListComponent, RentalDetailsComponent
  ],
  declarations: [RentalComponent, RentalListComponent, RentalDetailsComponent]
})
export class LeaseModule { }
