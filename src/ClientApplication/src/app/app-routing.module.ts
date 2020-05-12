import { HomeComponent } from './manage/home/home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent, RegisterComponent, AuthModule } from '@lib/auth';
// import { LoginComponent } from '../../projects/auth/src/lib/login/login.component';

// import { AuthModule } from './../../projects/auth/src/lib/auth.module';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: RegisterComponent}
  // {path: 'property', loadChildren: '../../projects/property-manager/src/app/app.module-export#AppPmModule'}
];


@NgModule({
  imports: [
    AuthModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
