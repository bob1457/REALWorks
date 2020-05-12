import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashContractComponent } from './dash-contract.component';

describe('DashContractComponent', () => {
  let component: DashContractComponent;
  let fixture: ComponentFixture<DashContractComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashContractComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashContractComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
