import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HouseTableComponent } from './house-table.component';

describe('HouseTableComponent', () => {
  let component: HouseTableComponent;
  let fixture: ComponentFixture<HouseTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HouseTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HouseTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
