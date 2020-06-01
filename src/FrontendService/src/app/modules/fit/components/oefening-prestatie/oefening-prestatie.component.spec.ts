import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OefeningPrestatieComponent } from './oefening-prestatie.component';

describe('OefeningPrestatieComponent', () => {
  let component: OefeningPrestatieComponent;
  let fixture: ComponentFixture<OefeningPrestatieComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OefeningPrestatieComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OefeningPrestatieComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
