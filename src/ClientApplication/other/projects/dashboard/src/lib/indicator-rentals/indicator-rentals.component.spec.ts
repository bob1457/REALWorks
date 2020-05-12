import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IndicatorRentalsComponent } from './indicator-rentals.component';

describe('IndicatorRentalsComponent', () => {
  let component: IndicatorRentalsComponent;
  let fixture: ComponentFixture<IndicatorRentalsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IndicatorRentalsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IndicatorRentalsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
