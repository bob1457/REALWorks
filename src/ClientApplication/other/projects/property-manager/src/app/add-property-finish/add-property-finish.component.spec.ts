import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPropertyFinishComponent } from './add-property-finish.component';

describe('AddPropertyFinishComponent', () => {
  let component: AddPropertyFinishComponent;
  let fixture: ComponentFixture<AddPropertyFinishComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddPropertyFinishComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddPropertyFinishComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
