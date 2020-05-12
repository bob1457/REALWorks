import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AppErrorHandlingComponent } from './app-error-handling.component';

describe('AppErrorHandlingComponent', () => {
  let component: AppErrorHandlingComponent;
  let fixture: ComponentFixture<AppErrorHandlingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AppErrorHandlingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppErrorHandlingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
