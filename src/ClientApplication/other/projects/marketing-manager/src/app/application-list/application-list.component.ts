import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { PropertyListingState } from '../store/marketing.state';
import { getRentalApplicationList, getRentalApplicationDetails } from '../store/actions/marketing.actions';

@Component({
  selector: 'app-application-list',
  templateUrl: './application-list.component.html',
  styleUrls: ['./application-list.component.scss']
})
export class ApplicationListComponent implements OnInit {

  constructor(private store: Store<PropertyListingState>) { }

  ngOnInit() {
    debugger;
    return this.store.dispatch(getRentalApplicationList())  ;
  }

  GetApplicationDetails(id: number) {
    debugger;
    return this.store.dispatch(getRentalApplicationDetails({payload: id}));
  }

}
