import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SupportRoleInfoComponent } from './support-role-info.component';

describe('SupportRoleInfoComponent', () => {
  let component: SupportRoleInfoComponent;
  let fixture: ComponentFixture<SupportRoleInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SupportRoleInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SupportRoleInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
