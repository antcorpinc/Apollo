import { TestBed } from '@angular/core/testing';

import { FlatsResolverService } from './flats-resolver.service';

describe('FlatsResolverService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: FlatsResolverService = TestBed.get(FlatsResolverService);
    expect(service).toBeTruthy();
  });
});
