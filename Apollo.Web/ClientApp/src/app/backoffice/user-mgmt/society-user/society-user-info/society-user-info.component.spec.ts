import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SocietyUserInfoComponent } from './society-user-info.component';

describe('SocietyUserInfoComponent', () => {
  let component: SocietyUserInfoComponent;
  let fixture: ComponentFixture<SocietyUserInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SocietyUserInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SocietyUserInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
