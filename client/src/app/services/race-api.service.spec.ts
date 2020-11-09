import { TestBed } from '@angular/core/testing';

import { RaceApiService } from './race-api.service';

describe('RaceApiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RaceApiService = TestBed.get(RaceApiService);
    expect(service).toBeTruthy();
  });
});
