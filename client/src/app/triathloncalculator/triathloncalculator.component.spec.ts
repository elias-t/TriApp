import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TriathloncalculatorComponent } from './triathloncalculator.component';

describe('TriathloncalculatorComponent', () => {
  let component: TriathloncalculatorComponent;
  let fixture: ComponentFixture<TriathloncalculatorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TriathloncalculatorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TriathloncalculatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
