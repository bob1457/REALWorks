import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PropertyDetailsBasicComponent } from './property-details-basic.component';

describe('PropertyDetailsBasicComponent', () => {
  let component: PropertyDetailsBasicComponent;
  let fixture: ComponentFixture<PropertyDetailsBasicComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PropertyDetailsBasicComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PropertyDetailsBasicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
