import { updatePropertyListing } from './../store/actions/marketing.actions';
import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { PropertyListingState } from '../store/marketing.state';
import { getPropertyListing, getPropertyListingDetails, addPropertyListing } from '../store/actions/marketing.actions';
import { PropertyListing } from '@lib/app-core';

@Component({
  selector: 'app-property-listing',
  templateUrl: './property-listing.component.html',
  styleUrls: ['./property-listing.component.scss']
})
export class PropertyListingComponent implements OnInit {

  constructor(private store: Store<PropertyListingState>) { }

  ngOnInit() {
    debugger;
    // return this.propertyService.getPropertyList().subscribe((pList: Property[]) => {this.list = pList; console.log(pList)});
    return this.store.dispatch(getPropertyListing());
  }

  GetPropertyListingDetails(id: number) {
    debugger;
    return this.store.dispatch(getPropertyListingDetails({payload: id}));
  }

  AddPropertyListing() {

    const listing: PropertyListing = {
      id: 0,
      title: 'New Listing',
      rentalPropertyId: 8,
      listingDesc: 'Newly listed ...',
      // listingStatus: 'pending',
      monthlyRent: 1500,
      notes: 'Just listed',
      contactName: 'Michelle Lu',
      contactTel: '123-456-7890',
      contactEmail: 'ml@real.com',
      contactSMS: '',
      contactOther: ''
    };



    debugger;
    return this.store.dispatch(addPropertyListing({payload: listing}));

  }

  UpdatePropertyListing() {

    const listing: any = {
      id: 3,
      title: 'Updated Listing',
      rentalPropertyId: 8,
      listingDesc: 'Newly listed ...',
      // listingStatus: 'pending',
      monthlyRent: 1500,
      notes: 'Just listed',
      contactName: 'Michelle Lu',
      contactTel: '778-456-7890',
      contactEmail: 'ppt@real.com',
      contactSMS: '',
      contactOther: ''
    };

    debugger;
    return this.store.dispatch(updatePropertyListing({payload: listing}));

  }

}
