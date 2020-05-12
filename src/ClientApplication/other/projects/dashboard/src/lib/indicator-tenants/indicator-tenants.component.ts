import { PropertyTenant } from '@lib/app-core';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'lib-indicator-tenants',
  templateUrl: './indicator-tenants.component.html',
  styleUrls: ['./indicator-tenants.component.css']
})
export class IndicatorTenantsComponent implements OnInit {

  @Input() tenantList: PropertyTenant[];

  constructor() { }

  ngOnInit() {
  }

}
