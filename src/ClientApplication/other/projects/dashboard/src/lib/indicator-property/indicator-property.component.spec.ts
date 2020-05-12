import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IndicatorPropertyComponent } from './indicator-property.component';

describe('IndicatorPropertyComponent', () => {
  let component: IndicatorPropertyComponent;
  let fixture: ComponentFixture<IndicatorPropertyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IndicatorPropertyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IndicatorPropertyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
