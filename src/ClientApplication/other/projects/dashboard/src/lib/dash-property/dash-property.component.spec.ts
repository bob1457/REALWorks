import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashPropertyComponent } from './dash-property.component';

describe('DashPropertyComponent', () => {
  let component: DashPropertyComponent;
  let fixture: ComponentFixture<DashPropertyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashPropertyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashPropertyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
