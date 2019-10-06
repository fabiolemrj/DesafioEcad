import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatemusicAuthorComponent } from './createmusic-author.component';

describe('CreatemusicAuthorComponent', () => {
  let component: CreatemusicAuthorComponent;
  let fixture: ComponentFixture<CreatemusicAuthorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreatemusicAuthorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreatemusicAuthorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
