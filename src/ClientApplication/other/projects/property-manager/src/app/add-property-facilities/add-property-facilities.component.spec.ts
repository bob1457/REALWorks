import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPropertyFacilitiesComponent } from './add-property-facilities.component';

describe('AddPropertyFacilitiesComponent', () => {
  let component: AddPropertyFacilitiesComponent;
  let fixture: ComponentFixture<AddPropertyFacilitiesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddPropertyFacilitiesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddPropertyFacilitiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
