import { PropertyListing, RentalApplication } from '@lib/app-core';
import * as marketing from './reducers';
import { createFeatureSelector } from '@ngrx/store';


export interface PropertyListingState   { //extends  EntityState<Property>
  loading: boolean | false;
  loaded: boolean | false;
  listings: PropertyListing[] | null;
  listing: PropertyListing | null;
  applications: RentalApplication[] | null;
  application: RentalApplication | null;

  // ownersOfProperty: PropertyOwner[] | null;
  // selectedOwner: PropertyOwner | null;
  // contracts: ManagementContract[] | null;
  // contractsForProperty: ManagementContract[] | null;
  // selectedContract: ManagementContract | null;
  errorMessage: string | null;
}

export const reducer = {
  marketing: marketing.reducer
};

export const selectMarketingState = createFeatureSelector<PropertyListingState>('marketing');



