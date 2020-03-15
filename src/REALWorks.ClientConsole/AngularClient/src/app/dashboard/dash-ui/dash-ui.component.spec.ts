import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashUiComponent } from './dash-ui.component';

describe('DashUiComponent', () => {
  let component: DashUiComponent;
  let fixture: ComponentFixture<DashUiComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashUiComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashUiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
