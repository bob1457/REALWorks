import { Actions, createEffect, ofType } from '@ngrx/effects';
import { MarketingService, PropertyListing, RentalApplication } from '@lib/app-core';
import { Injectable } from '@angular/core';

import * as ListingActions from '../actions/marketing.actions';
import { switchMap, map, catchError, tap } from 'rxjs/operators';
import { of } from 'rxjs';

@Injectable()
export class MarketingEffects {
  constructor(
    private actions$: Actions,
    private marketingService: MarketingService
  ) {}

  getPropertyListing$ = createEffect(() =>
    this.actions$.pipe(
      // ofType('[Property] Get Property List'),
      ofType(ListingActions.getPropertyListing),
      tap(() => console.log('got here for property listing!!!')),
      switchMap(() =>
        this.marketingService.getAllPropertyListings().pipe(
          map((listings: PropertyListing[]) => ({
            type: '[Marketing] Get Property Listing Success',
            payload: listings
          })),
          // tap(res => {console.log('response: ' + res); }),
          catchError(
            err => {
              return of('[Marketing] Get Property Listing Failure', err.error);
            } // EMPTY
          )
        )
      )
    )
  );

  getPropertyListingDetails$ = createEffect(() =>
    this.actions$.pipe(
      // ofType('[Property] Get Property List'),
      ofType(ListingActions.getPropertyListingDetails),
      tap(() => console.log('got here for property listing details !!!')),
      map(action => action.payload),
      switchMap((payload) =>
        this.marketingService.getPropertyListingDetails(payload).pipe(
          map((listing: PropertyListing) => ({
            type: '[Marketing] Get Property Listing Details Success',
            payload: listing
          })),
          // tap(res => {console.log('response: ' + res); }),
          catchError(
            err => {
              return of('[Marketing] Get Property Listing Details Failure', err.error);
            } // EMPTY
          )
        )
      )
    )
  );

  addPropertyListing$ = createEffect(() =>
    this.actions$.pipe(
      // ofType('[Property] Get Property List'),
      ofType(ListingActions.addPropertyListing),
      tap(() => console.log('got here to add property listing !!!')),
      map(action => action.payload),
      switchMap((payload) =>
        this.marketingService.addPropertyListing(payload).pipe(
          map((listing: PropertyListing) => ({
            type: '[Marketing] Add Property Listing Success',
            payload: listing
          })),
          // tap(res => {console.log('response: ' + res); }),
          catchError(
            err => {
              return of('[Marketing] Add Property Listing Failure', err.error);
            } // EMPTY
          )
        )
      )
    )
  );

  updatePropertyListing$ = createEffect(() =>
    this.actions$.pipe(
      // ofType('[Property] Get Property List'),
      ofType(ListingActions.updatePropertyListing),
      tap(() => console.log('got here to update property listing !!!')),
      map(action => action.payload),
      switchMap((payload) =>
        this.marketingService.updatePropertyListing(payload).pipe(
          map((listing: PropertyListing) => ({
            type: '[Marketing] Update Property Listing Success',
            payload: listing
          })),
          // tap(res => {console.log('response: ' + res); }),
          catchError(
            err => {
              return of('[Marketing] Update Property Listing Failure', err.error);
            } // EMPTY
          )
        )
      )
    )
  );

  getRentalApplications$ = createEffect(() =>
    this.actions$.pipe(
      // ofType('[Property] Get Property List'),
      ofType(ListingActions.getRentalApplicationList),
      tap(() => console.log('got here for rental application list!!!')),
      switchMap(() =>
        this.marketingService.getAllRentalApplications().pipe(
          map((applications: RentalApplication[]) => ({
            type: '[Marketing] Get Rental Applications Success',
            payload: applications
          })),
          // tap(res => {console.log('response: ' + res); }),
          catchError(
            err => {
              return of('[Marketing] Get Rental Applications Failure', err.error);
            } // EMPTY
          )
        )
      )
    )
  );


}
