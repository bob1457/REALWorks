import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashListingComponent } from './dash-listing.component';

describe('DashListingComponent', () => {
  let component: DashListingComponent;
  let fixture: ComponentFixture<DashListingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashListingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashListingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
