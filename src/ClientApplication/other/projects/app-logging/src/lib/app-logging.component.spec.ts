import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AppLoggingComponent } from './app-logging.component';

describe('AppLoggingComponent', () => {
  let component: AppLoggingComponent;
  let fixture: ComponentFixture<AppLoggingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AppLoggingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppLoggingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
