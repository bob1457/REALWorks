import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PropertyRoutingModule } from './property-routing.module';

import { PropertyComponent } from './property/property.component';
import { PropertyListComponent } from './property-list/property-list.component';
import { PropertyDetailsComponent } from './property-details/property-details.component';

import { FlexLayoutModule } from '../../../node_modules/@angular/flex-layout';
import { AppMaterialModule } from '../app-material/app-material.module';
import { FormsModule } from '../../../node_modules/@angular/forms';
import { Ng4LoadingSpinnerModule } from '../../../node_modules/ng4-loading-spinner';

@NgModule({
  imports: [
    CommonModule,
    AppMaterialModule,
    FlexLayoutModule,
    FormsModule,
    Ng4LoadingSpinnerModule,
    PropertyRoutingModule
  ],
  exports: [
    PropertyComponent,
    PropertyListComponent,
    PropertyDetailsComponent
  ],
  declarations: [PropertyComponent, PropertyListComponent, PropertyDetailsComponent]
})
export class PropertyModule { }
