import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { PropertyLeaseState } from '../store/lease-state';
import { getAllLeases } from '../store/actions/lease.actions';

@Component({
  selector: 'app-all-leases',
  templateUrl: './all-leases.component.html',
  styleUrls: ['./all-leases.component.scss']
})
export class AllLeasesComponent implements OnInit {

  constructor(private store: Store<PropertyLeaseState>) { }

  ngOnInit() {
    debugger;
    // return this.propertyService.getPropertyList().subscribe((pList: Property[]) => {this.list = pList; console.log(pList)});
    return this.store.dispatch(getAllLeases())  ;
  }

}
