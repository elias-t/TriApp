import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RaceModalComponent } from './race-modal.component';

describe('RaceModalComponent', () => {
  let component: RaceModalComponent;
  let fixture: ComponentFixture<RaceModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RaceModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RaceModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
