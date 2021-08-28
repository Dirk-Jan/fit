import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { PrestatieDagComponent } from './prestatie-dag.component';

describe('PrestatieDagComponent', () => {
  let component: PrestatieDagComponent;
  let fixture: ComponentFixture<PrestatieDagComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ PrestatieDagComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrestatieDagComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
