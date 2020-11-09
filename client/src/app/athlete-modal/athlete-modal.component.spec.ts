import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AthleteModalComponent } from './athlete-modal.component';

describe('AthleteModalComponent', () => {
  let component: AthleteModalComponent;
  let fixture: ComponentFixture<AthleteModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AthleteModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AthleteModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
