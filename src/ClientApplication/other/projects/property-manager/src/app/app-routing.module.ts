import { CommonModule } from '@angular/common';
import { PropertyHomeComponent } from './property-home/property-home.component';
import { PropertyListComponent } from './property-list/property-list.component';
import { PropertyDetailsComponent } from './property-details/property-details.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OwnerListComponent } from './owner-list/owner-list.component';


const routes: Routes = [ // only for standalone app
  // { path: 'property', component: PropertyHomeComponent,
  //   children: [
  //     {path: 'list', component: PropertyListComponent},
  //     {path: 'owners', component: OwnerListComponent}
  //   ]
  // },
  // { path: 'owners', component: OwnerListComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
