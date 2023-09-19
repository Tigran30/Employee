import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEmployeeComponent } from './addeditemployee.component';

describe('AddEmployeeComponent', () => {
  let component: AddEmployeeComponent;
  let fixture: ComponentFixture<AddEmployeeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddEmployeeComponent]
    });
    fixture = TestBed.createComponent(AddEmployeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
