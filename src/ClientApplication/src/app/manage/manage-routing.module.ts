import { AuthGuard } from './../helpers/auth.guard';

// import { DashboardComponent } from './../../../projects/dashboard/src/lib/dashboard.component';
// import { ProfileComponent } from './../../../projects/auth/src/lib/profile/profile.component';
import { ProfileComponent, ProfileHomeComponent } from '@lib/auth';
// import { ProfileComponent } from '../../../projects/auth/src/lib/profile/profile.component';
import { HomeComponent } from './home/home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
// import { DashhomeComponent } from '../../../projects/dashboard/src/lib/dashhome/dashhome.component';
import { DashboardComponent } from '@lib/dashboard';

const routes: Routes = [
  {path: 'Manage',
    component: HomeComponent,
    canActivate: [AuthGuard],
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full'},
      { path: 'dashboard', component: DashboardComponent},
      { path: 'profile', component: ProfileHomeComponent},
      // { path: 'property', loadChildren: '../../../projects/property-manager/src/app/app.module-export#AppPmModule'}
      // tslint:disable-next-line:max-line-length
      { path: 'property', loadChildren: () => import('../../../projects/property-manager/src/app/app.module-export').then(m => m.AppPmModule)},
      // tslint:disable-next-line:max-line-length
      { path: 'marketing', loadChildren: () => import('../../../projects/marketing-manager/src/app/app.module export').then(m => m.AppMkModule)},
      { path: 'lease', loadChildren: () => import('../../../projects/lease-manager/src/app/app.module-export').then(m => m.AppLMModule)},
      // tslint:disable-next-line:max-line-length
      { path: 'main', loadChildren: () => import('../../../projects/business-manager/src/app/app.module-export').then(m => m.AppBmModule)}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ManageRoutingModule { }
