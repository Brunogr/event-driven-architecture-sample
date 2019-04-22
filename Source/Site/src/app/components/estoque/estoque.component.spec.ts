import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EstoqueComponent } from './estoque.component';

describe('SorteioComponent', () => {
  let component: EstoqueComponent;
  let fixture: ComponentFixture<EstoqueComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EstoqueComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EstoqueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
