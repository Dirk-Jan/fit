import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { WorkoutItemComponent } from './workout-item.component';

describe('WorkoutItemComponent', () => {
  let component: WorkoutItemComponent;
  let fixture: ComponentFixture<WorkoutItemComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkoutItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkoutItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
