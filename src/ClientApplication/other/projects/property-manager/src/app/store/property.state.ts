import { Property, PropertyOwner, ManagementContract} from '@lib/app-core';
import * as property from './reducers';
import { createFeatureSelector } from '@ngrx/store';
import { createEntityAdapter, EntityState, EntityAdapter } from '@ngrx/entity';

export interface PropertyState   { //extends  EntityState<Property>
  loading: boolean | false;
  loaded: boolean | false;
  properties: Property[] | null;
  property: Property | null;
  owners: PropertyOwner[] | null;
  ownersOfProperty: PropertyOwner[] | null;
  selectedOwner: PropertyOwner | null;
  contracts: ManagementContract[] | null;
  contractsForProperty: ManagementContract[] | null;
  selectedContract: ManagementContract | null;
  errorMessage: string | null;
}

export const reducer = {
  property: property.reducer
};

export const selectPropertyState = createFeatureSelector<PropertyState>('property');
