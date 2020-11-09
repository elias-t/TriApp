import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewresultsComponent } from './viewresults.component';

describe('ViewresultsComponent', () => {
  let component: ViewresultsComponent;
  let fixture: ComponentFixture<ViewresultsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewresultsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewresultsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
