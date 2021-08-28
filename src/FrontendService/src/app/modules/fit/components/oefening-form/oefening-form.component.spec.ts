import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { OefeningFormComponent } from './oefening-form.component';

describe('OefeningFormComponent', () => {
  let component: OefeningFormComponent;
  let fixture: ComponentFixture<OefeningFormComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ OefeningFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OefeningFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
