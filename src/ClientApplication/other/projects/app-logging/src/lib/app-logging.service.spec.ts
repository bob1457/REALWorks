import { TestBed } from '@angular/core/testing';

import { AppLoggingService } from './app-logging.service';

describe('AppLoggingService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AppLoggingService = TestBed.get(AppLoggingService);
    expect(service).toBeTruthy();
  });
});
