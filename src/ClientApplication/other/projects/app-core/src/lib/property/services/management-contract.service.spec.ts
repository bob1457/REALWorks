import { TestBed } from '@angular/core/testing';

import { ManagementContractService } from './management-contract.service';

describe('ManagementContractService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ManagementContractService = TestBed.get(ManagementContractService);
    expect(service).toBeTruthy();
  });
});
