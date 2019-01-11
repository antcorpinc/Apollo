import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SocietyUserListComponent } from './society-user-list.component';

describe('SocietyUserListComponent', () => {
  let component: SocietyUserListComponent;
  let fixture: ComponentFixture<SocietyUserListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SocietyUserListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SocietyUserListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
