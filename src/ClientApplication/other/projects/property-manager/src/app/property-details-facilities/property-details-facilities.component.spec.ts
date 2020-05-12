import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PropertyDetailsFacilitiesComponent } from './property-details-facilities.component';

describe('PropertyDetailsFacilitiesComponent', () => {
  let component: PropertyDetailsFacilitiesComponent;
  let fixture: ComponentFixture<PropertyDetailsFacilitiesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PropertyDetailsFacilitiesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PropertyDetailsFacilitiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
