import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashTenantComponent } from './dash-tenant.component';

describe('DashTenantComponent', () => {
  let component: DashTenantComponent;
  let fixture: ComponentFixture<DashTenantComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashTenantComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashTenantComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
