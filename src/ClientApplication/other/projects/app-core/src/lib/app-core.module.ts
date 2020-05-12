import { NgModule } from '@angular/core';
import { AppCoreComponent } from './app-core.component';
import { PropertyModule } from './property/property.module';
import { MarketingModule } from './marketing/marketing.module';

@NgModule({
  declarations: [AppCoreComponent],
  imports: [
  PropertyModule,
  MarketingModule],
  exports: [AppCoreComponent]
})
export class AppCoreModule { }
