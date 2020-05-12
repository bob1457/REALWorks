import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppBmComponent } from './app.component';
import { ManageHomeComponent } from './manage-home/manage-home.component';
import { CalenderComponent } from './calender/calender.component';

@NgModule({
  declarations: [
    AppBmComponent,
    ManageHomeComponent,
    CalenderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppBmComponent]
})
export class AppModule { }
