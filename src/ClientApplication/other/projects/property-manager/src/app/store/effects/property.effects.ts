import { Injectable } from '@angular/core';
import { createEffect, Actions, ofType } from '@ngrx/effects';
import { PropertyService, PropertyOwnerService, ManagementContractService, Property,
  ManagementContract, PropertyStatus, PropertyOwner } from '@lib/app-core';
import { mergeMap, catchError, map, tap, switchMap } from 'rxjs/operators';
import { EMPTY, of } from 'rxjs';

import * as PropertyActions from '../actions/property.actions';
import { PropertyActive } from 'projects/app-core/src/lib/property/models/property-active.model';




@Injectable()
export class PropertyEffects {
  constructor(
    private actions$: Actions,
    private propertyService: PropertyService,
    private propertyOwnerService: PropertyOwnerService,
    private contractService: ManagementContractService
  ) {}

  getPropertyList$ = createEffect(() =>
    this.actions$.pipe(
      // ofType('[Property] Get Property List'),
      ofType(PropertyActions.getPropertyList),
      tap(() => console.log('got here for property list!!!')),
      switchMap(() =>
        this.propertyService.getPropertyList().pipe(
          map((properties: Property[]) => ({
            type: '[Property] Get Property List Success',
            payload: properties
          })),
          // tap(res => {console.log('response: ' + res); }),
          catchError(
            err => {
              return of('[Property] Get Property List Failure', err.error);
            } // EMPTY
          )
        )
      )
    )
  ); //mergeMap was used

  getPropertyDetails$ = createEffect(() =>
    this.actions$.pipe(
      // ofType('[Property] Get Property List'),
      ofType(PropertyActions.getPropertyDetails),
      // tap(() => console.log('got here: ')),
      map(action => action.payload),
      switchMap((payload) =>
        this.propertyService.getPropertyDetails(payload).pipe(
          tap(() => console.log('got here 2: ' + payload)),
          map((property: Property) => ({
            type: '[Property] Get Property Details Success',
            payload: property
          })),
          // tap(res => {console.log('response: ' + res); }),
          catchError(
            err => {
              return of(PropertyActions.getPropertyDetailsFailure([err.error]));
            } // EMPTY // return of('[Property] Get Property Details Failure', err.error);
          )
        )
      )
    )
  );

  addProperty$ = createEffect(() =>
    this.actions$.pipe(
      // ofType('[Property] Get Property List'),
      ofType(PropertyActions.addProperty),
      // tap(() => console.log('got here: ')),
      map(action => action.payload),
      switchMap((payload) =>
        this.propertyService.addProperty(payload).pipe(
          tap(() => console.log('called property service: ' + payload)),
          map((property: Property) => ({
            type: '[Property] Add Property Success',
            payload: property
          })),
          // tap(res => {console.log('response: ' + res); }),
          catchError(
            err => {
              return of('[Property] Add Property Failure', err.error);
            } // EMPTY
          )
        )
      )
    )
  );

  updateProperty$ = createEffect(() =>
    this.actions$.pipe(
      // ofType('[Property] Get Property List'),
      ofType(PropertyActions.updateProperty),
      // tap(() => console.log('got here: ')),
      map(action => action.payload),
      switchMap((payload) =>
        this.propertyService.updateProperty(payload).pipe(
          tap(() => console.log('called property service for update: ' + payload)),
          map((property: Property) => ({
            type: '[Property] Update Property Success',
            payload: property
          })),
          // tap(res => {console.log('response: ' + res); }),
          catchError(
            err => {
              return of('[Property] Update Property Failure', err.error);
            } // EMPTY
          )
        )
      )
    )
  );

  updatePropertyStatus$ = createEffect(() =>
    this.actions$.pipe(
      // ofType('[Property] Get Property List'),
      ofType(PropertyActions.updatePropertyStatus),
      // tap(() => console.log('got here: ')),
      map(action => action.payload),
      switchMap((payload) =>
        this.propertyService.updatePropertyStatus(payload).pipe(
          tap(() => console.log('called property service for status change: ' + payload)),
          map((status: Property) => ({ // PropertyStatus
            type: '[Property] Update Property Status Success',
            payload: status
          })),
          // tap(res => {console.log('response: ' + res); }),
          catchError(
            err => {
              return of('[Property] Update Property Status Failure', err.error);
            } // EMPTY
          )
        )
      )
    )
  );


  removeProperty$ = createEffect(() =>
    this.actions$.pipe(
      // ofType('[Property] Get Property List'),
      ofType(PropertyActions.removeProperty),
      // tap(() => console.log('got here: ')),
      map(action => action.payload),
      switchMap((payload) =>
        this.propertyService.removeProperty(payload).pipe(
          // tap(() => console.log('called property service: ' + payload)),
          map((active: Property) => ({ // PropertyActive
            type: '[Property] Remove Property Success',
            payload: active
          })),
          // tap(res => {console.log('response: ' + res); }),
          catchError(
            err => {
              return of('[Property] Remove Property Failure', err.error);
            } // EMPTY
          )
        )
      )
    )
  );

  getPropertyOwnerList$ = createEffect(() =>
    this.actions$.pipe(
      // ofType('[Property] Get Property List'),
      ofType(PropertyActions.getPropertyOwnerList),
      tap(() => console.log('got here to call service for retrieving owners')),
      switchMap(() =>
        this.propertyService.getPropertyOwnerList().pipe(
          map((owners: PropertyOwner[]) => ({
            type: '[Property] Get Property Owner List Success',
            payload: owners
          })),
          // tap(res => {console.log('response: ' + res); }),
          catchError(
            err => {
              // return of('[Property] Get Property Owner List Failure', err.error);
              return of(PropertyActions.getPropertyOwnerListFailure(err.error));
            } // EMPTY
          )
        )
      )
    )
  );


  getPropertyOwnerDetails$ = createEffect(() =>
    this.actions$.pipe(
      // ofType('[Property] Get Property List'),
      ofType(PropertyActions.getPropertyOwnerDetails),
      // tap(() => console.log('got here: ')),
      map(action => action.payload),
      switchMap((payload) =>
        this.propertyOwnerService.getPropertyDetails(payload).pipe(
          tap(() => console.log('got here for owner details: ' + payload)),
          map((owner: PropertyOwner) => ({
            type: '[Property] Get Property Owner Details Success',
            payload: owner
          })),
          // tap(res => {console.log('response: ' + res); }),
          catchError(
            err => {
              return of(PropertyActions.getPropertyOwnerDetailsFailure([err.error]));
            } // EMPTY // return of('[Property] Get Property Details Failure', err.error);
          )
        )
      )
    )
  );

  addPropertyOwner$ = createEffect(() =>
    this.actions$.pipe(
      // ofType('[Property] Get Property List'),
      ofType(PropertyActions.addPropertyOwner),
      // tap(() => console.log('got here: ')),
      map(action => action.payload),
      switchMap((payload) =>
        this.propertyOwnerService.addPropertyOwner(payload).pipe( // this.propertyService.addOwner(payload).pipe(
          tap(() => console.log('called property owner service to add owner: ' + payload)),
          map(( owner: PropertyOwner) => ({
            type: '[Property] Add Property Owner Success',
            payload: owner
          })),
          // tap(res => {console.log('response: ' + res); }),
          catchError(
            err => {
              return of('[Property] Add Property Owner Failure', err.error);
            } // EMPTY
          )
        )
      )
    )
  );

  updatePropertyOwner$ = createEffect(() =>
    this.actions$.pipe(
      // ofType('[Property] Get Property List'),
      ofType(PropertyActions.updatePropertyOwner),
      // tap(() => console.log('got here: ')),
      map(action => action.payload),
      switchMap((payload) =>
        this.propertyOwnerService.updateOwner(payload).pipe(
          tap(() => console.log('called property service for update: ' + payload)),
          map((owner: PropertyOwner) => ({
            type: '[Property] Update Property Owner Success',
            payload: owner
          })),
          // tap(res => {console.log('response: ' + res); }),
          catchError(
            err => {
              return of('[Property] Update Property Failure', err.error);
            } // EMPTY
          )
        )
      )
    )
  );

  removePropertyOwner$ = createEffect(() =>
    this.actions$.pipe(
      // ofType('[Property] Get Property List'),
      ofType(PropertyActions.removePropertyOwner),
      // tap(() => console.log('got here: ')),
      map(action => action.payload),
      switchMap((payload) =>
        this.propertyOwnerService.removeOwner(payload).pipe(
          tap(() => console.log('called property owner service: ' + payload)),
          map((owner: any) => ({ // PropertyActive
            type: '[Property] Remove Property Owner Success' // ,
            // payload: owner
          })),
          // tap(res => {console.log('response: ' + res); }),
          catchError(
            err => {
              return of('[Property] Remove Property Owner Failure', err.error);
            } // EMPTY
          )
        )
      )
    )
  );


  getContractList$ = createEffect(() =>
    this.actions$.pipe(
      // ofType('[Property] Get Property List'),
      ofType(PropertyActions.getContractList),
      // tap(() => console.log('got here to call service for retrieving contracts')),
      switchMap(() =>
        this.contractService.getManagementContractList().pipe(
          map((contracts: ManagementContract[]) => ({
            type: '[Property] Get Contract List Success',
            payload: contracts
          })),
          // tap(res => {console.log('response: ' + res); }),
          catchError(
            err => {
              return of('[[Property] Get Contract List Failure', err.error);
            } // EMPTY
          )
        )
      )
    )
  );

  getContractDetails$ = createEffect(() =>
    this.actions$.pipe(
      // ofType('[Property] Get Property List'),
      ofType(PropertyActions.getContractDetails),
      tap(() => console.log('got here for contract details: ')),
      map(action => action.payload),
      switchMap((payload) =>
        this.contractService.getManagementContractDetails(payload).pipe(
          // tap(() => console.log('got here 2: ' + payload)),
          map((contract: ManagementContract) => ({
            type: '[Property] Get Contract Details Success',
            payload: contract
          })),
          // tap(res => {console.log('response: ' + res); }),
          catchError(
            err => {
              return of(PropertyActions.getContractDetailsFailure([err.error]));
            } // EMPTY // return of('[Property] Get Property Details Failure', err.error);
          )
        )
      )
    )
  );

  addManagementContract$ = createEffect(() =>
    this.actions$.pipe(
      // ofType('[Property] Get Property List'),
      ofType(PropertyActions.addManagementContract),
      // tap(() => console.log('got here: ')),
      map(action => action.payload),
      switchMap((payload) =>
        this.contractService.addManagementContract(payload).pipe( // this.propertyService.addOwner(payload).pipe(
          tap(() => console.log('called property owner service to add contract: ' + payload)),
          map(( contract: ManagementContract) => ({
            type: '[Property] Add Management Contract Success',
            payload: contract
          })),
          // tap(res => {console.log('response: ' + res); }),
          catchError(
            err => {
              return of('[Property] Add Management Contract Failure', err.error);
            } // EMPTY
          )
        )
      )
    )
  );

  updateContract$ = createEffect(() =>
    this.actions$.pipe(
      // ofType('[Property] Get Property List'),
      ofType(PropertyActions.updateContract),
      // tap(() => console.log('got here: ')),
      map(action => action.payload),
      switchMap((payload) =>
        this.contractService.updateManagementContract(payload).pipe(
          tap(() => console.log('called contract service for update: ' + payload)),
          map((contract: ManagementContract) => ({
            type: '[Property] Update Contract Success',
            payload: contract
          })),
          // tap(res => {console.log('response: ' + res); }),
          catchError(
            err => {
              return of('[Property] Update Contract Failure', err.error);
            } // EMPTY
          )
        )
      )
    )
  );

}
