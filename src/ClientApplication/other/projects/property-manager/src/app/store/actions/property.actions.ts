import { createAction, props } from '@ngrx/store';

import { Property, PropertyStatus, ManagementContract } from '@lib/app-core';
import { PropertyOwner } from '@lib/app-core';


debugger;
/**
 * Get Property List Actions
 */
export const getPropertyList = createAction(
  '[Property] Get Property List'
);

export const getPropertyListSuccess = createAction(
  '[Property] Get Property List Success',
  props<{payload: Property[]}>()
);

export const getPropertyListFailure = createAction(
  '[Property] Get Property List Failure',
  // props<{payload: any}>()
  (errorMessage = 'Error loading property list') => {
    return ({ payload: { errorMessage } });
  }
);

/**
 * Get Property Details Actions
 */
export const getPropertyDetails = createAction(
  '[Property] Get Property Details',
  props<{payload: number}>()
);

export const getPropertyDetailsSuccess = createAction(
  '[Property] Get Property Details Success',
  props<{payload: Property}>()
);

export const getPropertyDetailsFailure = createAction(
  '[Property] Get Property Details Failure',
  // props<{payload: any}>()
  (errorMessage = 'Error loading property details') => {
    return ({ payload: { errorMessage } });
  }
);

/**
 * Add Property Actions
 */

export const addProperty = createAction(
  '[Property] Add Property',
  props<{payload: Property}>()
);

export const addPropertySuccess = createAction(
  '[Property] Add Property Success',
  props<{payload: Property}>()
);

export const addPropertyFailure = createAction(
  '[Property] Add Property Failure',
  // props<{payload: any}>()
  (errorMessage = 'Error adding property') => ({ payload: { errorMessage }})

);

/**
 * Update Property Actions
 */

export const updateProperty = createAction(
  '[Property] Update Property',
  props<{payload: Property}>()
);

export const updatePropertySuccess = createAction(
  '[Property] Update Property Success',
  props<{payload: Property}>()
);

export const updatePropertyFailure = createAction(
  '[Property] Update Property Failure',
  // props<{payload: any}>()
  (errorMessage = 'Error adding property') => ({ payload: { errorMessage }})

);

export const updatePropertyStatus = createAction(
  '[Property] Update Property Status',
  props<{payload: Property}>() // PropertyStatus
);

export const updatePropertyStatusSuccess = createAction(
  '[Property] Update Property Status Success',
  props<{payload: Property}>()
);

export const updatePropertyStatusFailure = createAction(
  '[Property] Update Property Status Failure',
  // props<{payload: PropertyStatus}>()
  (errorMessage = 'Error adding property') => ({ payload: { errorMessage }})
);

/**
 * Remove Prooperty Actions
 */
export const removeProperty = createAction(
  '[Property] Remove Property Status',
  props<{payload: any}>()
);

export const removePropertySuccess = createAction(
  '[Property] Remove Property Success',
  props<{payload: any}>()
);

export const removePropertyFailure = createAction(
  '[Property] Remove Property Failure',
  // props<{payload: PropertyStatus}>()
  (errorMessage = 'Error removing property') => ({ payload: { errorMessage }})
);


/**
 * Get Property Owner List Actions
 */

export const getPropertyOwnerList = createAction(
  '[Property] Get Property Owner List'
);

export const getPropertyOwnerListSuccess = createAction(
  '[Property] Get Property Owner List Success',
  props<{payload: PropertyOwner[]}>()
);

export const getPropertyOwnerListFailure = createAction(
  '[Property] Get Property List Failure',
  // props<{payload: any}>()
  (errorMessage = 'Error loading property Owner list') => {
    return ({ payload: { errorMessage } });
  }
);


/**
 * Get Property Owner Details Actions
 */

export const getPropertyOwnerDetails = createAction(
  '[Property] Get Property Owner Details',
  props<{payload: number}>()
);

export const getPropertyOwnerDetailsSuccess = createAction(
  '[Property] Get Property Owner Details Success',
  props<{payload: PropertyOwner}>()
);

export const getPropertyOwnerDetailsFailure = createAction(
  '[Property] Get Property Owner Details Failure',
  // props<{payload: any}>()
  (errorMessage = 'Error loading property Owner Details') => {
    return ({ payload: { errorMessage } });
  }
);


/**
 * Add Property Owner Actions
 */

export const addPropertyOwner = createAction(
  '[Property] Add Property Owner',
  props<{payload: PropertyOwner}>()
);

export const addPropertyOwnerSuccess = createAction(
  '[Property] Add Property Owner Success',
  props<{payload: PropertyOwner}>()
);

export const addPropertyOwnerFailure = createAction(
  '[Property] Add Property Owner Failure',
  // props<{payload: PropertyOwner}>()
  (errorMessage = 'Error adding property owner') => ({ payload: { errorMessage }})
);

/**
 * Update Property Owner Actions
 */

export const updatePropertyOwner = createAction(
  '[Property] Update Property Owner',
  props<{payload: PropertyOwner}>()
);

export const updatePropertyOwnerSuccess = createAction(
  '[Property] Update Property Owner Success',
  props<{payload: any}>()
);

export const updatePropertyOwnerFailure = createAction(
  '[Property] Update Property Owner Failure',
  // props<{payload: any}>()
  (errorMessage = 'Error updating property Owner') => ({ payload: { errorMessage }})

);

/**
 * Remove Property Owner From Property Actions
 */
export const removePropertyOwner = createAction(
  '[Property] Remove Property Owner',
  props<{payload: any}>()
);

export const removePropertyOwnerSuccess = createAction(
  '[Property] Remove Property Owner Success',
  props<{payload: any}>()
);

export const removePropertyOwnerFailure = createAction(
  '[Property] Remove Property Owner Failure',
  // props<{payload: PropertyStatus}>()
  (errorMessage = 'Error removing property owner') => ({ payload: { errorMessage }})
);

/**
 * Get Management Contract List Actions
 */
export const getContractList = createAction(
  '[Property] Get Contract List'
);

export const getContractListSuccess = createAction(
  '[Property] Get Contract List Success',
  props<{payload: ManagementContract[]}>()
);

export const getContractListFailure = createAction(
  '[Property] Get Contract List Failure',
  // props<{payload: any}>()
  (errorMessage = 'Error loading contract list') => {
    return ({ payload: { errorMessage } });
  }
);


/**
 * Get Management Contract Details Actions
 */

export const getContractDetails = createAction(
    '[Property] Get Contract Details',
    props<{payload: number}>()
  );

export const getContractDetailsSuccess = createAction(
    '[Property] Get Contract Details Success',
    props<{payload: ManagementContract}>()
  );

export const getContractDetailsFailure = createAction(
    '[Property] Get Property Details Failure',
    // props<{payload: any}>()
    (errorMessage = 'Error loading Contract details') => {
      return ({ payload: { errorMessage } });
    }
  );

/**
 * Add Property Management Contract Actions
 */

export const addManagementContract = createAction(
  '[Property] Add Management Contract',
  props<{payload: ManagementContract}>()
);

export const addManagementContractSuccess = createAction(
  '[Property] Add Management Contract Success',
  props<{payload: ManagementContract}>()
);

export const addManagementContractFailure = createAction(
  '[Property] Add Management Contract Failure',
  // props<{payload: PropertyOwner}>()
  (errorMessage = 'Error adding management contract') => ({ payload: { errorMessage }})
);

export const updateContract = createAction(
  '[Property] Update Contract',
  props<{payload: ManagementContract}>()
);

export const updateContractSuccess = createAction(
  '[Property] Update Contract Success',
  props<{payload: ManagementContract}>()
);

export const updateContractFailure = createAction(
  '[Property] Update Contract Failure',
  // props<{payload: any}>()
  (errorMessage = 'Error updating management contract') => ({ payload: { errorMessage }})

);
