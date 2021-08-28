import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { OefeningenOverzichtPage } from './oefeningen-overzicht.page';

describe('OefeningenOverzichtPage', () => {
  let component: OefeningenOverzichtPage;
  let fixture: ComponentFixture<OefeningenOverzichtPage>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ OefeningenOverzichtPage ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OefeningenOverzichtPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
