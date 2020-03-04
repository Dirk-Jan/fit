import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OefeningenOverzichtPage } from './oefeningen-overzicht.page';

describe('OefeningenOverzichtPage', () => {
  let component: OefeningenOverzichtPage;
  let fixture: ComponentFixture<OefeningenOverzichtPage>;

  beforeEach(async(() => {
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
