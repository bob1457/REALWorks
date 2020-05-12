import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IndicatorTenantsComponent } from './indicator-tenants.component';

describe('IndicatorTenantsComponent', () => {
  let component: IndicatorTenantsComponent;
  let fixture: ComponentFixture<IndicatorTenantsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IndicatorTenantsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IndicatorTenantsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
