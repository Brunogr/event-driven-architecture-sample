import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CartelaComponent } from './cartela.component';

describe('CartelaComponent', () => {
  let component: CartelaComponent;
  let fixture: ComponentFixture<CartelaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CartelaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CartelaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
