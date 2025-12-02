import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Orden } from './orden';

describe('Orden', () => {
  let component: Orden;
  let fixture: ComponentFixture<Orden>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Orden]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Orden);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
