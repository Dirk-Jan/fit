import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { PrestatieFormComponent } from './prestatie-form.component';

describe('PrestatieFormComponent', () => {
  let component: PrestatieFormComponent;
  let fixture: ComponentFixture<PrestatieFormComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ PrestatieFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrestatieFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
