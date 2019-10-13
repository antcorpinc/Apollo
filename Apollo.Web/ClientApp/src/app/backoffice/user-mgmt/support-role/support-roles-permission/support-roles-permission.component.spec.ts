import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SupportRolesPermissionComponent } from './support-roles-permission.component';

describe('SupportRolesPermissionComponent', () => {
  let component: SupportRolesPermissionComponent;
  let fixture: ComponentFixture<SupportRolesPermissionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SupportRolesPermissionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SupportRolesPermissionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
