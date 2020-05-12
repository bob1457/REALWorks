import { createAction, props } from '@ngrx/store';
import { PropertyListing } from '@lib/app-core';
import { RentalApplication } from 'projects/app-core/src/public-api';


debugger;
/**
 * Get Property Listing Actions
 */
export const getPropertyListing = createAction(
  '[Marketing] Get Property Listing'
);

export const getPropertyListingSuccess = createAction(
  '[Marketing] Get Property Listing Success',
  props<{payload: PropertyListing[]}>()
);

export const getPropertyListingFailure = createAction(
  '[Marketing] Get Property Listing Failure',
  // props<{payload: any}>()
  (errorMessage = 'Error loading property listing') => {
    return ({ payload: { errorMessage } });
  }
);

/**
 * Get Property Listing Details Actions
 */
export const getPropertyListingDetails = createAction(
  '[Marketing] Get Property Listing Details',
  props<{payload: number}>()
);

export const getPropertyListingDetailsSuccess = createAction(
  '[Marketing] Get Property Listing Details Success',
  props<{payload: PropertyListing}>()
);

export const getPropertyListingDetailsFailure = createAction(
  '[Marketing] Get Property List Details Failure',
  // props<{payload: any}>()
  (errorMessage = 'Error loading property Details listing') => {
    return ({ payload: { errorMessage } });
  }
);

/**
 * Add Property Listing Actions
 */

export const addPropertyListing = createAction(
  '[Marketing] Add Property Listing',
  props<{payload: PropertyListing}>()
);

export const addPropertyListingSuccess = createAction(
  '[Marketing] Add Property Listing Success',
  props<{payload: PropertyListing}>()
);

export const addPropertyListingFailure = createAction(
  '[Property] Add Property Listing Failure',
  // props<{payload: any}>()
  (errorMessage = 'Error adding property') => ({ payload: { errorMessage }})

);

/**
 * Update Property Listing Actions
 */

export const updatePropertyListing = createAction(
  '[Marketing] Update Property Listing',
  props<{payload: PropertyListing}>()
);

export const updatePropertyListingSuccess = createAction(
  '[Marketing] Update Property Listing Success',
  props<{payload: PropertyListing}>()
);

export const updatePropertyListingFailure = createAction(
  '[Property] Update Property Listing Failure',
  // props<{payload: any}>()
  (errorMessage = 'Error updating property') => ({ payload: { errorMessage }})

);

/**
 * Get all rental application List Actions
 */
export const getRentalApplicationList = createAction(
  '[Marketing] Get Rental Applications'
);

export const getRentalApplicationListSuccess = createAction(
  '[Marketing] Get Rental Applications Success',
  props<{payload: RentalApplication[]}>()
);

export const getRentalApplicationListFailure = createAction(
  '[Marketing] Get Rental Applications Failure',
  // props<{payload: any}>()
  (errorMessage = 'Error loading property listing') => {
    return ({ payload: { errorMessage } });
  }
);

/**
 * Get all rental application Details Actions
 */
export const getRentalApplicationDetails = createAction(
  '[Marketing] Get Rental Application Details',
  props<{payload: number}>()
);

export const getRentalApplicationDetailsSuccess = createAction(
  '[Marketing] Get Rental Application Details Success',
  props<{payload: RentalApplication}>()
);

export const getRentalApplicationDetailsFailure = createAction(
  '[Marketing] Get Rental Application Details Failure',
  // props<{payload: any}>()
  (errorMessage = 'Error loading application details') => {
    return ({ payload: { errorMessage } });
  }
);
