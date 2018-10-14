import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SupportUserInfoComponent } from './support-user-info.component';

describe('SupportUserInfoComponent', () => {
  let component: SupportUserInfoComponent;
  let fixture: ComponentFixture<SupportUserInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SupportUserInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SupportUserInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
