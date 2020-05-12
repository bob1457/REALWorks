import { TestBed } from '@angular/core/testing';

import { AppErrorHandlingService } from './app-error-handling.service';

describe('AppErrorHandlingService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AppErrorHandlingService = TestBed.get(AppErrorHandlingService);
    expect(service).toBeTruthy();
  });
});
