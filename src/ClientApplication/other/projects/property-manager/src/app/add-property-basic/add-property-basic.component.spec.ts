import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPropertyBasicComponent } from './add-property-basic.component';

describe('AddPropertyBasicComponent', () => {
  let component: AddPropertyBasicComponent;
  let fixture: ComponentFixture<AddPropertyBasicComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddPropertyBasicComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddPropertyBasicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
