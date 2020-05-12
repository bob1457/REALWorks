
// import { propertyList } from './../../../../property-manager/src/app/store/reducers/property.reducer';
import { Observable } from 'rxjs';
import { Component, OnInit, Input } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { DashState } from '../store/dash.state';
import { getPropertyList, getContractList } from '../store/dash.actions';
import { Property } from '../models/property.model';
import { PropertyList } from '../store/dash.reducer';
import { PropertyOwner } from '../models/property-owner.model';
import { ManagementContract } from '../models/management-contract.model';

@Component({
  selector: 'lib-dash-property',
  templateUrl: './dash-property.component.html',
  styleUrls: ['./dash-property.component.css']
})
export class DashPropertyComponent implements OnInit {

  breakpoint: number;

  // $propertyList: Observable<Property[]>;  //Property[];
  @Input() propertyList: Property[];
  @Input() ownerList: PropertyOwner[];
  @Input() contractList: ManagementContract[];

  constructor(private store: Store<DashState>) { }

  ngOnInit() {
    this.breakpoint = (window.innerWidth <= 640) ? 2 : 1;
    // debugger;
    // this.store.dispatch(getPropertyList()) ;
    // this.store.dispatch(getContractList());
    // this.getPropertyList();
    console.log('passed: ' + this.ownerList);
  }

  onResize(event) {
    this.breakpoint = (event.target.innerWidth <= 640) ? 2 : 1;
  }

  // getPropertyList() {
  //   this.$propertyList = this.store.select(PropertyList);
  //   // this.store.pipe(select(getPropertyList)).subscribe((pList:Property[]) => {
  //   //   this.propertyList = pList;
  //   // });
  // }

  // getContractList() {

  // }

}
