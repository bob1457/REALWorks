import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { PropertyLeaseState } from '../store/lease-state';
import { getAllTenants } from '../store/actions/lease.actions';

@Component({
  selector: 'app-all-tenants',
  templateUrl: './all-tenants.component.html',
  styleUrls: ['./all-tenants.component.scss']
})
export class AllTenantsComponent implements OnInit {

  constructor(private store: Store<PropertyLeaseState>) { }

  ngOnInit() {
    debugger;
    // return this.propertyService.getPropertyList().subscribe((pList: Property[]) => {this.list = pList; console.log(pList)});
    return this.store.dispatch(getAllTenants())  ;
  }

}
