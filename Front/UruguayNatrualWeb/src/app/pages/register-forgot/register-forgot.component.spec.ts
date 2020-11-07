import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterForgotComponent } from './register-forgot.component';

describe('RegisterForgotComponent', () => {
  let component: RegisterForgotComponent;
  let fixture: ComponentFixture<RegisterForgotComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterForgotComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterForgotComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
