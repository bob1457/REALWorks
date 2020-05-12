import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IndicatorContractComponent } from './indicator-contract.component';

describe('IndicatorContractComponent', () => {
  let component: IndicatorContractComponent;
  let fixture: ComponentFixture<IndicatorContractComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IndicatorContractComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IndicatorContractComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
