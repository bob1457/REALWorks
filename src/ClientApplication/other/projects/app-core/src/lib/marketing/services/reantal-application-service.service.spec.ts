import { TestBed } from '@angular/core/testing';

import { ReantalApplicationServiceService } from './reantal-application-service.service';

describe('ReantalApplicationServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ReantalApplicationServiceService = TestBed.get(ReantalApplicationServiceService);
    expect(service).toBeTruthy();
  });
});
