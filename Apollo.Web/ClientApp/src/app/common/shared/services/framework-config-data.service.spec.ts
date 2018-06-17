import { TestBed, inject } from '@angular/core/testing';

import { FrameworkConfigDataService } from './framework-config-data.service';

describe('FrameworkConfigDataService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FrameworkConfigDataService]
    });
  });

  it('should be created', inject([FrameworkConfigDataService], (service: FrameworkConfigDataService) => {
    expect(service).toBeTruthy();
  }));
});
