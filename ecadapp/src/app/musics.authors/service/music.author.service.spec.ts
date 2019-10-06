import { TestBed } from '@angular/core/testing';

import { Music.AuthorService } from './music.author.service';

describe('Music.AuthorService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: Music.AuthorService = TestBed.get(Music.AuthorService);
    expect(service).toBeTruthy();
  });
});
