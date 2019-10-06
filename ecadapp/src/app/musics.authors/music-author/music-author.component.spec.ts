import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MusicAuthorComponent } from './music-author.component';

describe('MusicAuthorComponent', () => {
  let component: MusicAuthorComponent;
  let fixture: ComponentFixture<MusicAuthorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MusicAuthorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MusicAuthorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
