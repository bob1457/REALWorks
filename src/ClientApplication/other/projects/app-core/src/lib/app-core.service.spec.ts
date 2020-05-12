import { TestBed } from '@angular/core/testing';

import { AppCoreService } from './app-core.service';

describe('AppCoreService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AppCoreService = TestBed.get(AppCoreService);
    expect(service).toBeTruthy();
  });
});
