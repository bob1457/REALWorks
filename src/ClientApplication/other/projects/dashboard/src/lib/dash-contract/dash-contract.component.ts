import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { DashState } from '../store/dash.state';
import { getContractList } from '../store/dash.actions';

@Component({
  selector: 'lib-dash-contract',
  templateUrl: './dash-contract.component.html',
  styleUrls: ['./dash-contract.component.css']
})
export class DashContractComponent implements OnInit {

  breakpoint: number;

  constructor(private store: Store<DashState>) { }

  ngOnInit() {
    this.breakpoint = (window.innerWidth <= 640) ? 2 : 1;
    debugger;
    // return this.store.dispatch(getPropertyOwnerList()) ;
    return this.store.dispatch(getContractList()) ;
  }

}
