import { TestBed } from '@angular/core/testing';

import { BuildingsResolverService } from './buildings-resolver.service';

describe('BuildingsResolverService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BuildingsResolverService = TestBed.get(BuildingsResolverService);
    expect(service).toBeTruthy();
  });
});
