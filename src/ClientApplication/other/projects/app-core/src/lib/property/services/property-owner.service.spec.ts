import { TestBed } from '@angular/core/testing';

import { PropertyOwnerService } from './property-owner.service';

describe('PropertyOwnerService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PropertyOwnerService = TestBed.get(PropertyOwnerService);
    expect(service).toBeTruthy();
  });
});
