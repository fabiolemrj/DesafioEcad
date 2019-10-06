import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DeletemusicAuthorComponent } from './deletemusic-author.component';

describe('DeletemusicAuthorComponent', () => {
  let component: DeletemusicAuthorComponent;
  let fixture: ComponentFixture<DeletemusicAuthorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DeletemusicAuthorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeletemusicAuthorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
