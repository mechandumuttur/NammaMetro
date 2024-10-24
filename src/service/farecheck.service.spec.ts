import { TestBed } from '@angular/core/testing';

import { FarecheckService } from './farecheck.service';

describe('FarecheckService', () => {
  let service: FarecheckService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FarecheckService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
