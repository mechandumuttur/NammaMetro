import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListofpassengersComponent } from './listofpassengers.component';

describe('ListofpassengersComponent', () => {
  let component: ListofpassengersComponent;
  let fixture: ComponentFixture<ListofpassengersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListofpassengersComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListofpassengersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
