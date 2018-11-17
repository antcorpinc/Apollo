import { TestBed } from '@angular/core/testing';

import { SocietyDataService } from './society-data.service';

describe('SocietyDataService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SocietyDataService = TestBed.get(SocietyDataService);
    expect(service).toBeTruthy();
  });
});
