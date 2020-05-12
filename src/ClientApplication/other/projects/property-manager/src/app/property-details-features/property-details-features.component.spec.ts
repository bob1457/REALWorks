import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PropertyDetailsFeaturesComponent } from './property-details-features.component';

describe('PropertyDetailsFeaturesComponent', () => {
  let component: PropertyDetailsFeaturesComponent;
  let fixture: ComponentFixture<PropertyDetailsFeaturesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PropertyDetailsFeaturesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PropertyDetailsFeaturesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
