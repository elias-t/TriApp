import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TriathlonresultsComponent } from './triathlonresults.component';

describe('TriathlonresultsComponent', () => {
  let component: TriathlonresultsComponent;
  let fixture: ComponentFixture<TriathlonresultsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TriathlonresultsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TriathlonresultsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
