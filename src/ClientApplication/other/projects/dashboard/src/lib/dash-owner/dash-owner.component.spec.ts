import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashOwnerComponent } from './dash-owner.component';

describe('DashOwnerComponent', () => {
  let component: DashOwnerComponent;
  let fixture: ComponentFixture<DashOwnerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashOwnerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashOwnerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
