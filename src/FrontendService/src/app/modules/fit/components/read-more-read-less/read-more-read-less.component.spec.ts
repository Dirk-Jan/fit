import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { ReadMoreReadLessComponent } from './read-more-read-less.component';

describe('ReadMoreReadLessComponent', () => {
  let component: ReadMoreReadLessComponent;
  let fixture: ComponentFixture<ReadMoreReadLessComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ ReadMoreReadLessComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReadMoreReadLessComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
