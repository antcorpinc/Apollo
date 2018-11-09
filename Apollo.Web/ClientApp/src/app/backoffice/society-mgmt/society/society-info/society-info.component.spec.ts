import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SocietyInfoComponent } from './society-info.component';

describe('SocietyInfoComponent', () => {
  let component: SocietyInfoComponent;
  let fixture: ComponentFixture<SocietyInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SocietyInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SocietyInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
