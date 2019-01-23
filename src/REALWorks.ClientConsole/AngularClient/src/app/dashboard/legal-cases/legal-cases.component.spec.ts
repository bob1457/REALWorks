import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LegalCasesComponent } from './legal-cases.component';

describe('LegalCasesComponent', () => {
  let component: LegalCasesComponent;
  let fixture: ComponentFixture<LegalCasesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LegalCasesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LegalCasesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
