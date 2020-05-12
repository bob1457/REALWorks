import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashLeaseComponent } from './dash-lease.component';

describe('DashLeaseComponent', () => {
  let component: DashLeaseComponent;
  let fixture: ComponentFixture<DashLeaseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashLeaseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashLeaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
