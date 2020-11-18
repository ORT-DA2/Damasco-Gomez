import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HouseEditorComponent } from './house-editor.component';

describe('HouseEditorComponent', () => {
  let component: HouseEditorComponent;
  let fixture: ComponentFixture<HouseEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HouseEditorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HouseEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
