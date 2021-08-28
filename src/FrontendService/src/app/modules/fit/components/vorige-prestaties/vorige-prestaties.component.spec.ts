import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { VorigePrestatiesComponent } from './vorige-prestaties.component';

describe('VorigePrestatiesComponent', () => {
  let component: VorigePrestatiesComponent;
  let fixture: ComponentFixture<VorigePrestatiesComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ VorigePrestatiesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VorigePrestatiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
