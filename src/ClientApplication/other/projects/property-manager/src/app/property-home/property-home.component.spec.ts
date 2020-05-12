import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PropertyHomeComponent } from './property-home.component';

describe('PropertyHomeComponent', () => {
  let component: PropertyHomeComponent;
  let fixture: ComponentFixture<PropertyHomeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PropertyHomeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PropertyHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
