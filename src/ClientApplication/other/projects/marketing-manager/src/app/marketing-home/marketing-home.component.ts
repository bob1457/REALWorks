import { Component, OnInit } from '@angular/core';
import { PropertyListingState } from '../store/marketing.state';
import { Store } from '@ngrx/store';
import { getPropertyListing } from '../store/actions/marketing.actions';

@Component({
  selector: 'app-marketing-home',
  templateUrl: './marketing-home.component.html',
  styleUrls: ['./marketing-home.component.scss']
})
export class MarketingHomeComponent implements OnInit {

  constructor(private store: Store<PropertyListingState>) { }

  ngOnInit() {
    debugger;
    // return this.propertyService.getPropertyList().subscribe((pList: Property[]) => {this.list = pList; console.log(pList)});
    // return this.store.dispatch(getPropertyListing())  ;
  }

}
