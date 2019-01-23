import { AdminhomeComponent } from './../administration/adminhome/adminhome.component';
import { HomeComponent } from './home/home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { IndicatorComponent } from '../indicator/indicator.component';
import { DashUiComponent } from './dash-ui/dash-ui.component';
import { LoginComponent } from '../account/login/login.component';

// import { PropertyListComponent } from './property-list/property-list.component';
// import { RentalListComponent } from './rental-list/rental-list.component';

import { ScreeningComponent } from '../marketing/screening/screening.component';
import { TaskListComponent } from './task-list/task-list.component';
import { CalendarComponent } from './calendar/calendar.component';
import { MessagesComponent } from './messages/messages.component';
import { LegalCasesComponent } from './legal-cases/legal-cases.component';
import { DocumentationComponent } from './documentation/documentation.component';
import { OverviewComponent } from './overview/overview.component';
import { ReportingComponent } from './reporting/reporting.component';
import { LandlordListComponent } from './landlord-list/landlord-list.component';
import { TenantListComponent } from '../tenant/tenant-list/tenant-list.component';

// import components from feature module (not the ones from local module, which will be removed after testing )
import { PropertyComponent } from '../property/property/property.component';
import { PropertyListComponent } from '../property/property-list/property-list.component';
import { PropertyDetailsComponent } from '../property/property-details/property-details.component';

import { RentalListComponent } from '../lease/rental-list/rental-list.component';
import { RentalDetailsComponent } from '../lease/rental-details/rental-details.component';
import { RentalComponent } from '../lease/rental/rental.component';

import { MarketingComponent } from '../marketing/marketing/marketing.component';
import { ApplicationsComponent } from '../marketing/applications/applications.component';
import { ProfileComponent } from '../account/profile/profile.component';
import { AuthGuard } from '../app-core/helpers/auth.guard';

const routes: Routes = [
  { path: 'manage',
    component: HomeComponent,
    // canActivate: [AuthGuard],
    children: [ // for side bar navigation path/routing
      { path: '', redirectTo: 'dash_ui', pathMatch: 'full'},
      { path: 'dash_ui', component: DashUiComponent, canActivate: [AuthGuard]},
      { path: 'profile', component: ProfileComponent },

      { path: 'property', component: PropertyComponent},
      { path: 'property_list', component: PropertyListComponent},
      { path: 'property_details/:id', component: PropertyDetailsComponent},

      { path: 'lease_rental', component: RentalComponent},
      { path: 'rental_list', component: RentalListComponent},
      { path: 'rental_details/:id', component: RentalDetailsComponent},

      { path: 'property_owner', component: LandlordListComponent},
      { path: 'property_tenant', component: TenantListComponent},

      { path: 'marketing', component: MarketingComponent},
      { path: 'applications', component: ApplicationsComponent},

      { path: 'screening', component: ScreeningComponent},
      { path: 'task_list', component: TaskListComponent},
      { path: 'calendar', component: CalendarComponent},
      { path: 'messages', component: MessagesComponent},
      { path: 'legal_cases', component: LegalCasesComponent},
      { path: 'documentation', component: DocumentationComponent},
      { path: 'overview', component: OverviewComponent},
      { path: 'reporting', component: ReportingComponent},
      { path: 'administration', component: AdminhomeComponent}
    ]
  },
  {
    path: 'account/profile', component: ProfileComponent
  },
  { path: '**', component: LoginComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
