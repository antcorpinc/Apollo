import { TestBed } from '@angular/core/testing';

import { BuildingDataService } from './building-data.service';

describe('BuildingDataService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BuildingDataService = TestBed.get(BuildingDataService);
    expect(service).toBeTruthy();
  });
});
