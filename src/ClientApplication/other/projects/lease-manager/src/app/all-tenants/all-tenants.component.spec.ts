import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AllTenantsComponent } from './all-tenants.component';

describe('AllTenantsComponent', () => {
  let component: AllTenantsComponent;
  let fixture: ComponentFixture<AllTenantsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AllTenantsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AllTenantsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
