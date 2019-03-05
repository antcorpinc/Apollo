import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SupportRoleListComponent } from './support-role-list.component';

describe('SupportRoleListComponent', () => {
  let component: SupportRoleListComponent;
  let fixture: ComponentFixture<SupportRoleListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SupportRoleListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SupportRoleListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
