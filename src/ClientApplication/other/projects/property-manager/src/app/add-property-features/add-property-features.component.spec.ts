import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPropertyFeaturesComponent } from './add-property-features.component';

describe('AddPropertyFeaturesComponent', () => {
  let component: AddPropertyFeaturesComponent;
  let fixture: ComponentFixture<AddPropertyFeaturesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddPropertyFeaturesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddPropertyFeaturesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
