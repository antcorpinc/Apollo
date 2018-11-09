import { TestBed } from '@angular/core/testing';

import { LookupMasterService } from './lookup-master.service';

describe('LookupMasterService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LookupMasterService = TestBed.get(LookupMasterService);
    expect(service).toBeTruthy();
  });
});
