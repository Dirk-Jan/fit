import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { OefeningPage } from './oefening.page';

describe('OefeningComponent', () => {
  let component: OefeningPage;
  let fixture: ComponentFixture<OefeningPage>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ OefeningPage ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OefeningPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
