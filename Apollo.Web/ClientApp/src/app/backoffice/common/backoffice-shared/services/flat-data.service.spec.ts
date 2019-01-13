import { TestBed } from '@angular/core/testing';

import { FlatDataService } from './flat-data.service';

describe('FlatDataService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: FlatDataService = TestBed.get(FlatDataService);
    expect(service).toBeTruthy();
  });
});
